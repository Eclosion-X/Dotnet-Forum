<template>
	<view>
		<view class="avater_container">
			<image class="avater" :src="user.avater" mode="aspectFill"></image>
			<input placeholder="请输入用户名" maxlength="6" class="name" type="text" v-model="user.name" />
		</view>

		<view class="person_card">
			<view class="information_card flex_box">
				<view>
					<image class="information_edit" src="../../static/account.png" mode="aspectFill"></image>
				</view>
				<view class="information_container">
					<view class="information_title">
						<uni-badge size="small" text=" " absolute="rightTop" type="error">
							<text>学号</text>
						</uni-badge>
					</view>
					<view class="information_text">
						<input maxlength=20 type="text" placeholder="请输入学号" v-model="user.studentId" />
					</view>
				</view>
			</view>
			<view class="information_card flex_box">
				<view>
					<image class="information_edit" src="../../static/password.png" mode="aspectFill"></image>
				</view>
				<view class="information_container">
					<view class="information_title">
						<uni-badge size="small" text=" " absolute="rightTop" type="error">
							<text>密码</text>
						</uni-badge>
					</view>
					<view class="information_text">
						<input maxlength=20 type="text" password="true" placeholder="请输入密码" v-model="user.password" />
					</view>
				</view>
			</view>
			<view class="information_card flex_box">
				<view>
					<image class="information_edit" src="../../static/college.png" mode="aspectFill"></image>
				</view>
				<view class="information_container">
					<view class="information_title">
						<text>学院</text>
					</view>
					<view class="information_text">
						<input maxlength=20 type="text" placeholder="请输入学院" v-model="user.college" />
					</view>
				</view>
			</view>
			<view class="information_card flex_box">
				<view>
					<image class="information_edit" src="../../static/college.png" mode="aspectFill"></image>
				</view>
				<view class="information_container">
					<view class="information_title">
						<text>系别</text>
					</view>
					<view class="information_text">
						<input maxlength=20 type="text" placeholder="请输入系" v-model="user.department" />
					</view>
				</view>
			</view>
			<view class="information_card flex_box">
				<view>
					<image class="information_edit" src="../../static/gender.png" mode="aspectFill"></image>
				</view>
				<view class="information_container">
					<view class="information_title">
						<text>性别</text>
					</view>
					<view class="information_text">
						<view class="uni-list-cell-db">
							<picker @change="bindGenderChange" :value="user.gender" :range="genderArray">
								<view class="uni-input">{{ genderArray[user.gender] }}</view>
							</picker>
						</view>
					</view>
				</view>
			</view>
			<view class="information_card flex_box">
				<view>
					<image class="information_edit" src="../../static/phone.png" mode="aspectFill"></image>
				</view>
				<view class="information_container">
					<view class="information_title">
						<text>电话</text>
					</view>
					<view class="information_text">
						<input maxlength=20 type="text" placeholder="请输入电话" v-model="user.phone" />
					</view>
				</view>
			</view>
			<view class="information_card flex_box">
				<view>
					<image class="information_edit" src="../../static/mail.png" mode="aspectFill"></image>
				</view>
				<view class="information_container">
					<view class="information_title">
						<text>邮箱</text>
					</view>
					<view class="information_text">
						<input maxlength=50 type="text" placeholder="请输入邮箱" v-model="user.email" />
					</view>
				</view>
			</view>
			<view class="information_card flex_box">
				<view>
					<image class="information_edit" src="../../static/birthday.png" mode="aspectFill"></image>
				</view>
				<view class="information_container">
					<view class="information_title">
						<text>生日</text>
					</view>
					<view class="information_text">
						<view class="uni-list-cell-db">
							<picker mode="date" :value="user.birthday" @change="bindDateChange">
								<view class="uni-input">{{ user.birthday }}</view>
							</picker>
						</view>
					</view>
				</view>
			</view>
		</view>
		<button class="register_button" @click="register()">注 册</button>
		<button class="login_button" @click="login()">返回登陆</button>
		<uni-popup ref="popup_error" type="message">
			<uni-popup-message type="error" message="学号、密码、用户名不能为空" :duration="2000"></uni-popup-message>
		</uni-popup>
		<uni-popup ref="popup_error_password" type="message">
			<uni-popup-message type="error" message="密码长度需在6-16之间" :duration="2000"></uni-popup-message>
		</uni-popup>
		<uni-popup ref="popup_error_email" type="message">
			<uni-popup-message type="error" message="邮箱格式不正确" :duration="2000"></uni-popup-message>
		</uni-popup>
		<uni-popup ref="popup_error_phone" type="message">
			<uni-popup-message type="error" message="电话格式不正确" :duration="2000"></uni-popup-message>
		</uni-popup>
	</view>
</template>

<script>
	import * as userApi from "../../api/user.js"
	import * as config from "../../utils/config.js"

	export default {
		data() {

			return {
				genderArray: [
					'保密',
					'男',
					'女'
				],
				user: {
					studentId: '',
					password: '',
					name: '用户名',
					avater: '../../static/avater.jpg',
					gender: 0,
					phone: '',
					email: '',
					college: '',
					department: '',
					description: '这个人没有个性签名',
					birthday: this.getToday(),
				}
			}
		},
		onLoad() {
			this.refresh()
		},
		onShow() {
			this.refresh()
		},
		methods: {
			refresh() {
				if (config.checkToken()) {
					uni.reLaunch({
						url: '../index/index'
					})
				}
			},
			getGender() {
				return config.getGender(this.user.gender)
			},
			register() {
				if (this.user.studentId == '' || this.user.password == '' || this.user.name == '') {
					this.$refs.popup_error.open('top')
				} else if (this.user.password.length < 6 || this.user.password.length > 16) {
					this.$refs.popup_error_password.open('top')
				} else if (this.user.phone.length != 0 && !config.checkPhone(this.user.phone)) {
					this.$refs.popup_error_phone.open('top')
				} else if (this.user.email.length != 0 && !config.checkEmail(this.user.email)) {
					this.$refs.popup_error_email.open('top')
				} else {
					userApi.register(this.user).then(data => {
						if (typeof data === "undefined") {
							uni.showToast({
								title: '服务器错误',
								icon: "error",
								mask: true,
								duration: 2000
							})
						} else {
							if (data.code == 200) {
								// let token = data.data.token
								// config.saveTokenFroce(token)
								uni.showToast({
									title: '注册成功！请耐心等待审核',
									icon: "success",
									mask: true,
									duration: 2000
								})
								setTimeout(() => {
									uni.reLaunch({
										url: '../login/login'
									})
								}, config.waitTime)
							} else {
								uni.showToast({
									title: '注册失败：' + data.msg,
									icon: "error",
									mask: true,
									duration: 2000
								})
							}
						}
					})
				}
			},
			login() {
				uni.redirectTo({
					url: '../login/login'
				})
			},
			bindDateChange(e) { // 改变日期
				this.user.birthday = e.target.value
			},
			getToday() { // 获取今天
				const date = new Date();
				let year = date.getFullYear();
				let month = date.getMonth() + 1;
				let day = date.getDate();
				month = month > 9 ? month : '0' + month;
				day = day > 9 ? day : '0' + day;
				return `${year}-${month}-${day}`;
			},
			bindGenderChange(e) { // 改变性别
				this.user.gender = e.target.value
			}
		}
	}
</script>

<style>
	.flex_box {
		display: flex;
	}

	.avater_container {
		margin-top: 20rpx;
		text-align: center;
	}

	.avater {
		width: 300rpx;
		height: 300rpx;
		border-radius: 50%;
	}

	.name {
		width: 40%;
		margin-left: 30%;
		font-size: 40rpx;
		font-weight: bold;
		/* border-bottom: 2rpx solid #A0A0A0; */
		border-bottom: none;
	}

	.name:hover {
		border-bottom: 2rpx solid #A0C2E7;
	}

	.register_button {
		width: 90%;
		margin: 30rpx 5%;
		background-image: linear-gradient(to top, #48c6ef 0%, #6f86d6 100%);
		font-weight: bold;
		border-radius: 40rpx;
		box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
	}

	.login_button {
		width: 90%;
		margin: 30rpx 5%;
		background-image: linear-gradient(120deg, #f6d365 0%, #fda085 100%);
		font-weight: bold;
		border-radius: 40rpx;
		box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
	}

	.person_card {
		width: 90%;
		margin-left: 5%;
		margin-right: 5%;
		margin-top: 40rpx;
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
</style>
