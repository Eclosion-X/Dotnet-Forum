<template>
	<view>
		<view class="person_card">
			<view class="flex_box">
				<image class="person_avater" :src="user.avater" mode="aspectFill"></image>
				<view class="person_information">
					<text class="person_name">{{ user.name }}</text>
					<view class="person_description">
						<text>{{ user.description }}</text>
					</view>
					<text class="person_follow" @click="followDetail(0)">关注：</text>
					<text class="person_follow" @click="followDetail(0)">{{ user.following }}</text>
					<text class="person_follow inner_split" @click="followDetail(1)">粉丝：</text>
					<text class="person_follow" @click="followDetail(1)">{{ user.follower }}</text>
				</view>
			</view>
		</view>
		<view class="person_card">
			<view class="information_card flex_box">
				<view class="information_container">
					<view class="information_title">
						<text>学号</text>
					</view>
					<view class="information_text">
						<text>{{ user.studentId }}</text>
					</view>
				</view>
				<view @click="updateUser()">
					<image class="information_edit" src="../../static/right.png" mode="aspectFill"></image>
				</view>
			</view>
			<view class="information_card flex_box">
				<view class="information_container">
					<view class="information_title">
						<text>学院</text>
					</view>
					<view class="information_text">
						<text>{{ user.college }}</text>
					</view>
				</view>
				<view @click="updateUser()">
					<image class="information_edit" src="../../static/right.png" mode="aspectFill"></image>
				</view>
			</view>
			<view class="information_card flex_box">
				<view class="information_container">
					<view class="information_title">
						<text>系</text>
					</view>
					<view class="information_text">
						<text>{{ user.department }}</text>
					</view>
				</view>
				<view @click="updateUser()">
					<image class="information_edit" src="../../static/right.png" mode="aspectFill"></image>
				</view>
			</view>
			<view class="information_card flex_box">
				<view class="information_container">
					<view class="information_title">
						<text>性别</text>
					</view>
					<view class="information_text">
						<text>{{ getGender() }}</text>
					</view>
				</view>
				<view @click="updateUser()">
					<image class="information_edit" src="../../static/right.png" mode="aspectFill"></image>
				</view>
			</view>
			<view class="information_card flex_box">
				<view class="information_container">
					<view class="information_title">
						<text>电话</text>
					</view>
					<view class="information_text">
						<text>{{ user.phone }}</text>
					</view>
				</view>
				<view @click="updateUser()">
					<image class="information_edit" src="../../static/right.png" mode="aspectFill"></image>
				</view>
			</view>
			<view class="information_card flex_box">
				<view class="information_container">
					<view class="information_title">
						<text>邮箱</text>
					</view>
					<view class="information_text">
						<text>{{ user.email }}</text>
					</view>
				</view>
				<view @click="updateUser()">
					<image class="information_edit" src="../../static/right.png" mode="aspectFill"></image>
				</view>
			</view>
			<view class="information_card flex_box">
				<view class="information_container">
					<view class="information_title">
						<text>生日</text>
					</view>
					<view class="information_text">
						<text>{{ user.birthday }}</text>
					</view>
				</view>
				<view @click="updateUser()">
					<image class="information_edit" src="../../static/right.png" mode="aspectFill"></image>
				</view>
			</view>
		</view>

		<view class="person_card" v-if="user.primarySchool+user.juniorHighSchool+user.highSchool+user.university!=''">
			<view v-if="user.primarySchool!=''" class="information_card flex_box">
				<view class="information_container">
					<view class="information_title">
						<text>小学</text>
					</view>
					<view class="information_text">
						<text>{{ user.primarySchool }}</text>
					</view>
				</view>
				<view @click="updateUser()">
					<image class="information_edit" src="../../static/right.png" mode="aspectFill"></image>
				</view>
			</view>
			<view v-if="user.juniorHighSchool!=''" class="information_card flex_box">
				<view class="information_container">
					<view class="information_title">
						<text>初中</text>
					</view>
					<view class="information_text">
						<text>{{ user.juniorHighSchool }}</text>
					</view>
				</view>
				<view @click="updateUser()">
					<image class="information_edit" src="../../static/right.png" mode="aspectFill"></image>
				</view>
			</view>
			<view v-if="user.highSchool!=''" class="information_card flex_box">
				<view class="information_container">
					<view class="information_title">
						<text>高中</text>
					</view>
					<view class="information_text">
						<text>{{ user.highSchool }}</text>
					</view>
				</view>
				<view @click="updateUser()">
					<image class="information_edit" src="../../static/right.png" mode="aspectFill"></image>
				</view>
			</view>
			<view v-if="user.university!=''" class="information_card flex_box">
				<view class="information_container">
					<view class="information_title">
						<text>大学</text>
					</view>
					<view class="information_text">
						<text>{{ user.university }}</text>
					</view>
				</view>
				<view @click="updateUser()">
					<image class="information_edit" src="../../static/right.png" mode="aspectFill"></image>
				</view>
			</view>
		</view>

		<view class="person_card"
			v-if="user.hobby.other+user.hobby.music+user.hobby.book+user.hobby.movie+user.hobby.game+user.hobby.sport!=''">
			<view v-if="user.hobby.other!=''" class="information_card flex_box">
				<view class="information_container">
					<view class="information_title">
						<text>爱好</text>
					</view>
					<view class="information_text">
						<text>{{ user.hobby.other }}</text>
					</view>
				</view>
				<view @click="updateUser()">
					<image class="information_edit" src="../../static/right.png" mode="aspectFill"></image>
				</view>
			</view>
			<view v-if="user.hobby.music!=''" class="information_card flex_box">
				<view class="information_container">
					<view class="information_title">
						<text>喜欢音乐</text>
					</view>
					<view class="information_text">
						<text>{{ user.hobby.music }}</text>
					</view>
				</view>
				<view @click="updateUser()">
					<image class="information_edit" src="../../static/right.png" mode="aspectFill"></image>
				</view>
			</view>
			<view v-if="user.hobby.book!=''" class="information_card flex_box">
				<view class="information_container">
					<view class="information_title">
						<text>喜欢的书</text>
					</view>
					<view class="information_text">
						<text>{{ user.hobby.book }}</text>
					</view>
				</view>
				<view @click="updateUser()">
					<image class="information_edit" src="../../static/right.png" mode="aspectFill"></image>
				</view>
			</view>
			<view v-if="user.hobby.movie!=''" class="information_card flex_box">
				<view class="information_container">
					<view class="information_title">
						<text>喜欢的电影</text>
					</view>
					<view class="information_text">
						<text>{{ user.hobby.movie }}</text>
					</view>
				</view>
				<view @click="updateUser()">
					<image class="information_edit" src="../../static/right.png" mode="aspectFill"></image>
				</view>
			</view>
			<view v-if="user.hobby.game!=''" class="information_card flex_box">
				<view class="information_container">
					<view class="information_title">
						<text>喜欢的游戏</text>
					</view>
					<view class="information_text">
						<text>{{ user.hobby.game }}</text>
					</view>
				</view>
				<view @click="updateUser()">
					<image class="information_edit" src="../../static/right.png" mode="aspectFill"></image>
				</view>
			</view>
			<view v-if="user.hobby.sport!=''" class="information_card flex_box">
				<view class="information_container">
					<view class="information_title">
						<text>喜欢的运动</text>
					</view>
					<view class="information_text">
						<text>{{ user.hobby.sport }}</text>
					</view>
				</view>
				<view @click="updateUser()">
					<image class="information_edit" src="../../static/right.png" mode="aspectFill"></image>
				</view>
			</view>
		</view>

		<button v-if="user.admin" class="bottom_button manager" @click="manage()">管理页面</button>
		<button class="bottom_button function" @click="updateUser()">修改信息</button>
		<button class="bottom_button function" @click="updatePassword()">修改密码</button>
		<button class="bottom_button logout" @click="logout()">退出登陆</button>

		<view class="bottom_tips">
			<text>{{ '- 到底了 -' }}</text>
		</view>

		<uni-popup ref="popup_success" type="message">
			<uni-popup-message type="success" message="登出成功" :duration="3000"></uni-popup-message>
		</uni-popup>
		<uni-popup ref="popup_serve_error" type="message">
			<uni-popup-message type="error" message="服务器错误" :duration="3000"></uni-popup-message>
		</uni-popup>
		<uni-popup ref="popup_information_error" type="message">
			<uni-popup-message type="error" message="获取个人信息失败" :duration="3000"></uni-popup-message>
		</uni-popup>
	</view>
</template>

<script>
	import * as userApi from "../../api/user.js"
	import * as config from "../../utils/config.js"

	export default {
		data() {
			return {
				user: {
					studentId: 22920191234,
					name: '墨羽翎玖',
					college: '信息学院',
					department: '',
					gender: 1,
					avater: '../../static/avater.jpg',
					description: '来时山有雪，归时雪满山。',
					birthday: '2021-12-15',
					phone: '12312341234',
					email: '123456@qq.com',
					following: 100,
					follower: 100,
					primarySchool: '',
					juniorHighSchool: '',
					highSchool: '',
					university: '',
					admin: false,
					hobby: {
						other: '',
						music: '',
						book: '',
						movie: '',
						game: '',
						comic: '',
						sport: ''
					}
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
			refresh() { // 刷新个人信息
				if (config.checkToken()) {
					userApi.select().then(data => {
						if (typeof data === "undefined") {
							this.$refs.popup_serve_error.open('top')
						} else if (data.code == 200) {
							this.user.id = data.data.id
							this.user.studentId = data.data.studentId
							this.user.name = data.data.name
							this.user.college = data.data.college
							this.user.department = data.data.department
							this.user.gender = data.data.gender

							this.user.avater = "/api" + String(data.data.avater).replace(/\\/g, "/")

							this.user.description = data.data.description
							this.user.phone = data.data.phone
							this.user.email = data.data.email

							this.user.following = data.data.following
							this.user.follower = data.data.follower

							this.user.gmtCreate = data.data.gmt_create
							this.user.gmtModified = data.data.gmt_modified

							this.user.admin = data.data.admin

							this.user.primarySchool = data.data.primarySchool == null ? '' : data.data
								.primarySchool
							this.user.juniorHighSchool = data.data.juniorHighSchool == null ? '' : data.data
								.juniorHighSchool
							this.user.highSchool = data.data.highSchool == null ? '' : data.data.highSchool
							this.user.university = data.data.university == null ? '' : data.data.university

							this.user.hobby.other = data.data.hobby.other
							this.user.hobby.music = data.data.hobby.music
							this.user.hobby.book = data.data.hobby.book
							this.user.hobby.movie = data.data.hobby.movie
							this.user.hobby.game = data.data.hobby.game
							this.user.hobby.comic = data.data.hobby.comic
							this.user.hobby.sport = data.data.hobby.sport
						} else {
							this.$refs.popup_information_error.open('top')
						}
					})
				} else {
					uni.redirectTo({
						url: '../login/login'
					})
				}
			},
			getGender() {
				return config.getGender(this.user.gender)
			},
			manage() {
				uni.navigateTo({
					url: '/pages/manage/manage',
				})
			},
			updateUser() {
				uni.navigateTo({
					url: `/pages/personInfoChange/personInfoChange`,
				});
			},
			updatePassword() {
				console.log(this.user.studentId);
				uni.navigateTo({
					url: `/pages/personPasswordChange/personPasswordChange?studentId=` + String(this.user
						.studentId),
				});
			},
			logout() {
				userApi.logout().then(data => {
					if (typeof data === "undefined") {
						this.$refs.popup_serve_error.open('top')
					} else if (data.code == 200) {
						config.saveToken('')
						this.$refs.popup_success.open('top')
						setTimeout(() => {
							uni.redirectTo({
								url: '../login/login'
							})
						}, config.waitTime)
					} else {
						uni.showToast({
							title: '登出失败：' + data.msg,
							icon: "error",
							mask: true,
							duration: 2000
						})
					}
				})
			},
			followDetail(tab) {
				uni.navigateTo({
					url: `/pages/followDetail/followDetail?index=${tab}`,
				});
			}
		}
	}
</script>

<style>
	.flex_box {
		display: flex;
	}

	.inner_split {
		margin-left: 20rpx;
	}

	.person_card {
		width: 90%;
		margin-left: 5%;
		margin-right: 5%;
		margin-top: 40rpx;
		/* height: 160rpx; */
		background-color: #F0F0F0;
		padding-left: 10rpx;
		padding-top: 10rpx;
		padding-bottom: 10rpx;
		border-radius: 10rpx;
		box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
	}

	.person_avater {
		width: 150rpx;
		height: 150rpx;
		border-radius: 50%;
		margin-right: 20rpx;
	}

	.person_information {
		/* margin-top: 10rpx; */
		margin-left: 10rpx;
	}

	.person_name {
		font-size: 50rpx;
		font-weight: bold;
		width: 400rpx;
		display: -webkit-box;
		/*弹性伸缩盒子模型显示*/
		-webkit-box-orient: vertical;
		/*排列方式*/
		-webkit-line-clamp: 1;
		/*显示文本行数*/
		overflow: hidden;
		/*溢出隐藏*/
	}

	.person_follow {
		font-size: 30rpx;
		color: #5F5F5F;
	}

	.person_description {
		/* margin-top: 10rpx; */
		/* margin-left: 20rpx; */
		/* margin-right: 20rpx; */
		width: 400rpx;
		color: #909090;
	}

	.person_description text {
		width: 100%;
		font-size: 30rpx;
		display: -webkit-box;
		/*弹性伸缩盒子模型显示*/
		-webkit-box-orient: vertical;
		/*排列方式*/
		-webkit-line-clamp: 1;
		/*显示文本行数*/
		overflow: hidden;
		/*溢出隐藏*/
	}

	.information_card {
		margin: 0;
		padding: 10rpx;
	}

	.information_container {
		width: 95%;
	}

	.information_title {
		color: #606060;
		font-size: 30rpx;
	}

	.information_text {
		font-size: 30rpx;
	}

	.information_edit {
		height: 40rpx;
		width: 40rpx;
		margin-top: 30rpx;
	}

	.bottom_tips {
		margin-top: 30rpx;
		text-align: center;
		height: 200rpx;
	}

	.bottom_tips text {
		color: #A8A8A8;
		bottom: 0;
	}

	.bottom_button {
		width: 90%;
		margin: 30rpx 5%;
		box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
	}

	.function {
		background-image: linear-gradient(120deg, #a1c4fd 0%, #c2e9fb 100%);
	}

	.manager {
		background-image: linear-gradient(to right, #43e97b 0%, #38f9d7 100%);
	}

	.logout {
		background-image: linear-gradient(to right, #f78ca0 0%, #f9748f 19%, #fd868c 60%, #fe9a8b 100%);
	}
</style>
