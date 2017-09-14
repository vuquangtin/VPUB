var app = angular.module('angularApp', [ 'ngRoute','anguFixedHeaderTable' ]);
var link = '/smeetingregister/sworld';
//var base_url = 'http://localhost:8080/meetingWebServices/sworld';
var base_url = 'https://dangkyhop.tphcm.gov.vn/sworldwebservice/sworld';
app.constant('urls', {
	BASE : '/smeetingregister/sworld',
});
var dataType = {
	dataType : "json"
};
var config = {
	headers : {
		'Content-Type' : 'application/json;charset=utf-8;'
	}
};
app.config(function($routeProvider, $locationProvider) {
	$routeProvider.when('/', {
		templateUrl : 'register.html',
		controller : 'registerController'
	}).when('/login', {
		templateUrl : 'login.html',
		controller : 'loginController'
	}).when('/detail', {
		templateUrl : 'detail.html',
		controller : 'detailcontroller'
	}).when('/email', {
		templateUrl : 'config_email.html',
		controller : 'configController'
	// $locationProvider.html5Mode(true);
	});
});
app.service('shareService', function() {
	this.token = '';
	this.orgid = '';
	this.meetingid = '';
	this.key = '';
	this.listOrg = {};
});
app
		.controller(
				'loginController',
				[
						'$scope',
						'$http',
						'$location',
						'shareService',
						function($scope, $http, $location, shareService) {

							$scope.login = function() {
								$scope.validatelogin = "Đang đăng nhập...!";
								var username = $scope.username;
								var password = $scope.password;
								$http
										.get(
												link + '/acount/login/'
														+ username + '/'
														+ password)
										.then(
												function(response) {
													if (response.data.status == "SUCCESS") {
														$scope.validatelogin = "Đăng nhập thành công!";
														$location
																.path("/email");
														shareService.orgid = response.data.obj.orgId;
														shareService.name = response.data.obj.name;
													} else {
														$scope.validatelogin = "Sai thông tin đăng nhập";
													}
												},
												function errorCallback(response) {
													console
															.log(response.statusText);
												});
							}
						} ]);

app
		.controller(
				'registerController',
				[
						'$scope',
						'$location',
						'$rootScope',
						'$http',
						'shareService',
						function($scope, $location, $rootScope, $http,
								shareService) {
							$scope.onloadFun = function() {
								$scope.isDisable = true;
								var str = $location.absUrl();
								var res = str.split("?");
								var keyString = res[1];
								if (keyString === undefined) {
									$scope.message = "Xin vui lòng kiểm tra Email thư mời họp, click vào link đăng ký thành phần tham dự để đăng ký người dự họp";
								} else {
									var key = keyString.replace("#/", "");
									shareService.key = key;
									$http
											.get(
													base_url
															+ '/auth/login/ten.nguyen/1')
											.then(
													function(response) {
														if (response.data.status == "SUCCESS") {
															shareService.token = response.data.obj.token;
															getDetaitMeeting(
																	shareService.token,
																	key);

														}
													},
													function errorCallback(
															response) {
													});
								}
							}
							function getDetaitMeeting(token, key) {
								$http
										.get(
												base_url
														+ '/partakermg/getdetailmeeting/'
														+ token + '/' + key)
										.then(
												function(response) {
													if (response.data.status == "SUCCESS") {
														viewDetail(
																response.data.obj.meeting,
																response.data.obj.orgPartakerName,
																response.data.obj.orgPartakerId);
														if(response.data.obj.meeting.meetingCodeStatus == false){
															$scope.message = "Lịch họp đã dời hoặc hoãn. Vui lòng kiểm tra Email để cập nhật lịch mới";
														}else{
															$scope.isDisable = false;
															viewDetail(
																	response.data.obj.meeting,
																	response.data.obj.orgPartakerName,
																	response.data.obj.orgPartakerId);
															$scope.listObj = response.data.obj.partaker;
															// $scope.informessage =
															// "";
															// vu.pham: check hoan lich doi lich
														
															getlistpartaker(
																	response.data.obj.orgPartakerId,
																	response.data.obj.meeting.id);
														}
													} else {
														$scope.message = "Xin vui lòng kiểm tra Email thư mời họp, click vào link đăng ký thành phần tham dự để đăng ký người dự họp";
													}
												},
												function errorCallback(response) {
												});
							}
							function viewDetail(meeting, orgPartaker,
									orgPartakerId) {
								var date = new Date(meeting.startTime);
								$scope.contain = meeting.name;
								var day = date.toLocaleDateString();
								var datetime = date.toLocaleTimeString();
								$scope.hour = day + " " + datetime;
								// $scope.hour = date
								// .getHours();
								// $scope.minute = date
								// .getMinutes();
								$scope.meetingCode = meeting.meetingInvitationName;
								$scope.orgname = orgPartaker;
								shareService.meetingid = meeting.id;
								shareService.orgid = orgPartakerId;

							}

							$scope.selectPartaker = function(user) {
								$scope.partakerObj = user;
							}

							$scope.addPartaker = function() {
								var orgID = shareService.orgid;
								var key = shareService.key;
								var meetingid = shareService.meetingid;
								var dataObj = {
									"id" : 0,
									"name" : $scope.txtname,
									"position" : $scope.txtposision,
									"email" : $scope.txtemail,
									"phone" : "0" + $scope.txtphone,
									"orgId" : orgID
								}
								var res = $http.post(base_url
										+ '/partakermg/insertpartakerstring/'
										+ shareService.token + '/'
										+ shareService.meetingid, dataObj,
										dataType, config);
								res.then(function(response) {
									if (response.data.status == "SUCCESS") {
										$scope.txtname = '';
										$scope.txtposision = '';
										$scope.txtemail = '';
										$scope.txtphone = '';
										$scope.frmAdd.txtname.$invalid = false;
										$scope.message = '';
										getlistpartaker(orgID, meetingid);
									}
								}, _error);
							}
							$scope.sendMail = function() {
								$scope.message = "Đang gửi...";
								var orgPartaker = shareService.orgid;
								var meetingID = shareService.meetingid;
								var session = shareService.token;
								var dataObj = {
									"orgPartaker" : orgPartaker,
									"subject" : $scope.subject,
									"content" : $scope.content,
									"meetingId" : meetingID
								};
								var res = $http.post(
										base_url + '/meetingmg/sendmail' + '/'
												+ session, dataObj, dataType,
										config);
								res.then(function(response) {
									if (response.data.status == "SUCCESS") {
										$scope.content = "";
										$scope.subject = "";
										$scope.message = "Thành công";
										$scope.$modalInstance.close();
									} else {
										$scope.message = "Thất bại";
									}

								}, _error);
							}
							$scope.updatePartaker = function() {
								var objUpdate = $scope.partakerObj;
								var session = shareService.token;
								var res = $http.post(base_url
										+ '/partakermg/updatepartakerstring'
										+ '/' + session, objUpdate, dataType,
										config);
								res
										.then(
												function(response) {
													if (response.data.status == "SUCCESS") {
														$scope.name = "";
														$scope.posision = "";
														$scope.email = "";
														$scope.phone = "";
														$scope.message = "Cập nhật thành công!";
													} else {
														$scope.message = "Cập nhật thất bại!";
													}
												}, _error);

							}
							$scope.deletePartaker = function() {
								var objDelete = $scope.partakerObj;
								var meetingID = shareService.meetingid;
								var session = shareService.token;
								$http
										.get(
												base_url
														+ '/partakermg/deletepartaker/'
														+ session + '/'
														+ objDelete.id + '/'
														+ meetingID)
										.then(
												function(response) {
													if (response.data.status == "SUCCESS") {
														$scope.listObj
																.splice(
																		$scope.listObj
																				.indexOf($scope.partakerObj),
																		1);
													}
													$scope.message = "Xóa thành công!";
												},
												function errorCallback(response) {
													$scope.message = "Xóa thất bại!";
													console
															.log(response.statusText);
												});
							}
							function _error(response) {
								console.log(response.statusText);
							}
							function getlistpartaker(orgid, meetingid) {
								var session = shareService.token;
								$http
										.get(
												base_url
														+ '/partakermg/getlistpartakerbyorgandmeetingid/'
														+ session + '/' + orgid
														+ '/' + meetingid)
										.then(
												function(response) {
													if (response.data.status == "SUCCESS") {
														$scope.listObj = response.data.obj;
													}
												},
												function errorCallback(response) {
													console
															.log(response.statusText);
												});
							}
						} ]);
app.controller('configController', [
		'$scope',
		'$rootScope',
		'$http',
		'$location',
		'shareService',
		function($scope, $rootScope, $http, $location, shareService) {
			$scope.loadToken = function() {
				$http.get(base_url + '/auth/login/ten.nguyen/1').then(
						function(response) {
							if (response.data.status == "SUCCESS") {
								$scope.token = response.data.obj.token;
								getEmailConfig($scope.token);
							}
						}, function errorCallback(response) {
						});
			}
			$scope.saveEmail = function() {
				var token = $scope.token;
				var smtp = $scope.emailConfig.smtp;
				var port = $scope.emailConfig.port;
				var user = $scope.emailConfig.user;
				var email = $scope.emailConfig.email;
				var pass = $scope.emailConfig.passWord;
				var title = $scope.emailConfig.title;
				var content = $scope.emailConfig.content;
				var dataObj = {
					"id" : 1,
					"smtp" : smtp,
					"port" : port,
					"user" : user,
					"email" : email,
					"passWord" : pass,
					"title" : title,
					"content" : content

				};
				var res = $http.post(base_url + '/meetingmg/registeremail/'
						+ token, dataObj, dataType, config);
				res.then(function(response) {
					if (response.data.status == "SUCCESS") {
						$scope.emailConfig = "";
						$scope.password = "";
						alert("Thành công");
						$location.path('/');
					} else {
						$scope.informessageadd = "Thêm mới thất bại!";
					}
				}, _error);

			}
			function getEmailConfig(token) {
				var res = $http.get(base_url + '/meetingmg/getemailconfig/'
						+ token);
				res.then(function(response) {
					if (response.data.status == "SUCCESS") {
						$scope.emailConfig = response.data.obj;
					}
				}, _error);

			}
			function _error(response) {
				console.log(response.statusText);
			}
		} ]);
app.controller('detailcontroller', [
		'$scope',
		'$http',
		'$location',
		'shareService',
		function($scope, $http, $location, shareService) {
			$http.get(base_url + '/auth/login/ten.nguyen/1').then(
					function(response) {
						if (response.data.status == "SUCCESS") {
							shareService.token = response.data.obj.token;
							var session = shareService.token;
						}
					}, function errorCallback(response) {
					});

			$scope.change = function() {
				var string = ('yyyy-MM-dd');
				var session = shareService.token;
				var dateTime = $scope.txtdateMeeting;
				var date = new Date(dateTime);
				var res = $http.get(base_url
						+ '/meetingmg/getlistMeetingByDate/' + session + "/"
						+ date);
				res.then(function(response) {
					if (response.data.status == "SUCCESS") {
						$scope.lstMeetings = response.data.obj;
					}
				}, _error);
			}
			$scope.getmeeting = function() {
				var meetingId = $scope.meetingSelect;
				var session = shareService.token;
				var res = $http.get(base_url
						+ '/meetingmg/getlistPartakerByIdMeeting/' + session + "/"
						+ meetingId);
				res.then(function(response) {
					if (response.data.status == "SUCCESS") {
						$scope.lstPartakers = response.data.obj;
					}
				}, _error);
			}
			function _error(response) {
				console.log(response.statusText);
			}
		} ]);
