<template>
	<view>
		<view class="cover_box">
			<image :src="albumInfo.cover" class="cover" mode="aspectFill"></image>
		</view>
		<view class="person_card">
			<view class="information_card flex_box">
				<view class="information_container">
					<view class="information_title">
						<uni-badge size="small" text=" " absolute="rightTop" type="error">
							<text>相册名称</text>
						</uni-badge>
					</view>
					<view class="information_text">
						<input maxlength=30 type="text" placeholder="请输入相册名称" v-model="albumInfo.name" />
					</view>
				</view>
			</view>
			<view class="information_card flex_box">

				<view class="information_container">
					<view class="information_title">
						<text>相册描述</text>
					</view>
					<view class="information_text">
						<input maxlength=200 type="text" placeholder="请输入相册描述" v-model="albumInfo.description" />
					</view>
				</view>
			</view>
		</view>
		<button class="register_button" @click="register()">修 改 相 册</button>
		<uni-popup ref="popup_error" type="message">
			<uni-popup-message type="error" message="相册名称不能为空" :duration="3000"></uni-popup-message>
		</uni-popup>
		<uni-popup ref="popup_success" type="message">
			<uni-popup-message type="success" message="修改成功" :duration="3000"></uni-popup-message>
		</uni-popup>
	</view>
</template>

<script>
	import * as config from "../../utils/config.js"
	import * as albumApi from "../../api/album.js"

	export default {
		data() {
			return {
				id: 0,
				albumInfo: {
					cover: '',
					name: '',
					description: ''
				},
				lock: false
			}
		},
		onLoad(options) {
			this.id = options.id
			if (typeof this.id == 'undefined') this.id = 0
		},
		onShow() {
			this.refresh()
		},
		methods: {
			refresh() {
				if (!config.checkToken()) {
					uni.redirectTo({
						url: '../login/login'
					})
				} else if (this.id == 0) {
					uni.reLaunch({
						url: '../album/album'
					})
				} else {
					albumApi.select(this.id).then(data => {
						if (typeof data === "undefined") {
							uni.showToast({
								title: '服务器错误',
								icon: "error",
								mask: true,
								duration: 2000
							})
						} else if (data.code != 200) {
							uni.showToast({
								title: data.msg,
								icon: "error",
								mask: true,
								duration: 2000
							})
						} else {
							this.albumInfo.cover = data.data.cover
							this.albumInfo.cover = "/api" + String(this.albumInfo.cover).replace(/\\/g, "/")
							this.albumInfo.name = data.data.name
							this.albumInfo.description = data.data.description
						}
					})
				}
			},
			register() {
				if (!this.lock) {
					this.lock = true
					albumApi.updateAlbumDetail(this.id, this.albumInfo.name, this.albumInfo.description, this.albumInfo
						.cover.substr(4)).then(data => {
						if (typeof data === "undefined") {
							uni.showToast({
								title: '服务器错误',
								icon: "error",
								mask: true,
								duration: 2000
							})
						} else if (data.code != 200) {
							uni.showToast({
								title: data.msg,
								icon: "error",
								mask: true,
								duration: 2000
							})
						} else {
							this.$refs.popup_success.open('top')
						}
					})
					this.lock = false
				}
			},
		}
	}
</script>

<style>
	.flex_box {
		display: flex;
	}

	.register_button {
		width: 90%;
		margin: 30rpx 5%;
		background-image: linear-gradient(to right, #43e97b 0%, #38f9d7 100%);
		font-weight: bold;
		border-radius: 40rpx;
		box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
	}


	.person_card {
		width: 90%;
		margin-left: 5%;
		margin-right: 5%;
		/* margin-top: 350rpx; */
		margin-top: 50rpx;
		/* height: 160rpx; */
		background-color: #FFFFFF;
		padding-left: 10rpx;
		padding-top: 10rpx;
		padding-bottom: 10rpx;
		border-radius: 10rpx;
		box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
	}

	.information_card {
		margin: 0;
		padding: 10rpx;
	}

	.information_container {
		display: flex;
		width: 95%;
		margin-left: 10rpx;
	}

	.information_title {
		color: #606060;
		font-size: 35rpx;
	}

	.information_text {
		margin-left: 20rpx;
		font-size: 35rpx;
	}

	.information_edit {
		height: 30rpx;
		width: 30rpx;
		margin-top: 10rpx;
	}

	.cover_box {
		width: 90%;
		margin-left: 5%;
		margin-top: 30rpx;
		text-align: center;
	}

	.cover {
		width: 450rpx;
		height: 450rpx;
	}
</style>
