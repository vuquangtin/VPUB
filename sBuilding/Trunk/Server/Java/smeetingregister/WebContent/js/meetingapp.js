var app = angular.module('detailMeetingApp', []);
app.controller('DetailmeetingController', meetingController);
var link = '/smeetingregister/sworld'
var dataType = {
	dataType : "json"
};
var config = {
	headers : {
		'Content-Type' : 'application/json;charset=utf-8;'
	}
};
function meetingController($scope, $http) {

	$scope.viewDetail = function() {
		$scope.partakerObj = {};
		$scope.customObjectAttend = {};
		$scope.message = "";
		var barcodes = $scope.barcode;
		$http
				.get(
						link + '/meetingregister/getdetailmeetingbybarcode/'
								+ barcodes).then(function(response) {
					if (response.data.status == "SUCCESS") {
						$scope.meeting = response.data.obj;
						$scope.partaker = response.data.obj.partaker;
						$scope.detail = response.data.obj.detailMeeting;
						$scope.hour = response.data.obj.hour;
						$scope.minute = response.data.obj.minute;
						$scope.orgname = response.data.obj.orgMeetingName;
						$scope.barcode = "";
						$scope.orgpartakerid = response.data.obj.orgPartakerId;
						bindingdata(response.data.obj);
					}
				}, function errorCallback(response) {
					console.log(response.statusText);
				});
	}
	$scope.selectPartaker = function(user) {
		$scope.partakerObj = user;
	}
	$scope.updatePartaker = function() {
		var objUpdate = $scope.partakerObj;
		var res = $http.post(link + '/partaker/updatepartaker', objUpdate,
				dataType, config);
		res.then(function(response) {
			if (response.data.status == "SUCCESS") {
				$scope.name = "";
				$scope.username = "";
				$scope.password = "";
				$scope.email = "";
				$scope.repassword = "";
				$scope.message = "Cập nhật thành công!";
			} else {
				$scope.message = "Cập nhật thất bại!";
			}
		}, _error);

	}
	$scope.deletePartaker = function() {
		var objDelete = $scope.partakerObj;
		$http.get(link + '/partaker/deletepartaker/' + objDelete.id).then(
				function(response) {
					if (response.data.status == "SUCCESS") {
						$scope.listObj.splice($scope.listObj
								.indexOf($scope.partakerObj), 1);
					}
					$scope.message = "Xóa thành công!";
				}, function errorCallback(response) {
					$scope.message = "Xóa thất bại!";
					console.log(response.statusText);
				});
	}
	$scope.addPartaker = function() {
		var customObjectTosyn = $scope.customObjectAttend;
		var dataObj = {
			"id" : 0,
			"name" : $scope.name,
			"position" : $scope.posision,
			"email" : $scope.email,
			"orgPartakerId" : $scope.customObjectAttend.orgattendId
		};
		var res = $http.post(link + '/partaker/insertpartaker', dataObj,
				dataType, config);
		res.then(function(response) {
			if (response.data.status == "SUCCESS") {
				$scope.name = "";
				$scope.posision = "";
				$scope.email = "";
				$scope.message = "Thêm mới thành công!"
			}
			bindingdata(customObjectTosyn);

		}, _error);
	}
	$scope.clearMessage = function() {
		$scope.message = "";

	}
	function bindingdata(obj) {
		$scope.customObjectAttend = obj;
		var partaker = obj.partaker;
		$http.get(link + '/partaker/getlistpartakerbyorgid/' + obj.orgattendId)
				.then(function(response) {
					if (response.data.status == "SUCCESS") {
						$scope.listObj = response.data.obj;
					}
				}, function errorCallback(response) {
					console.log(response.statusText);
				});
	}

	$scope.getlistmeeting = function() {
		$http.get(link + '/meetingregister/getlistmeeting').then(
				function(response) {
					if (response.data.status == "SUCCESS") {
						$scope.listMeeting = response.data.obj;
					}
				}, function errorCallback(response) {
					console.log(response.statusText);
				});
	}
	$scope.saveotherpartaker = function() {
		var meetingObj = $scope.selectedMeeting;
		var dataObj = {
			"meetingId" : meetingObj.id,
			"reason" : $scope.reason,
			"name" : $scope.partaker,
		};

		var res = $http.post(link + '/partaker/inserorgtpartaker', dataObj,
				dataType, config);
		res.then(function(response) {
			if (response.data.status == "SUCCESS") {
				$scope.reason = "";
				$scope.partaker = "";
			}
			bindingdata(response.data.obj);

		}, _error);
	}
	function _error(response) {
		console.log(response.statusText);
	}
	$scope.sendMail = function() {
		var customObjectTosyn = $scope.customObjectAttend;
		var orgPartaker = customObjectTosyn.orgattendId;
		var dataObj = {
			"orgPartaker" : orgPartaker,
			"subject" : $scope.subject,
			"content" : $scope.content,
		};
		var res = $http.post(link + '/meetingregister/sendmail', dataObj,
				dataType, config);
		res.then(function(response) {
			if (response.data.status == "SUCCESS") {
				$scope.content = "";
				$scope.subject = "";
			}
			bindingdata(response.data.obj);

		}, _error);
	}
	$scope.saveEmail = function() {
		var email = $scope.emailConfig;
		var pass = $scope.password;
		var repassWord = $scope.repassword;
		var result = conparePassWord(pass, repassWord);
		if (result) {
			var dataObj = {
				"id" : 1,
				"email" : email,
				"passWord" : pass
			};
			var res = $http.post(link + '/acount/registeremail', dataObj, dataType,
					config);
			res.then(function(response) {
				if (response.data.status == "SUCCESS") {
					$scope.emailConfig = "";
					$scope.password = "";
					$scope.repassword = "";
					$scope.message = "Cấu hình thành công!";
					$scope.validate = "";
				} else {
					$scope.message = "Cấu hình thất bại!";
				}
			}, _error);
		} else {
			$scope.validate = "Mật khẩu không khớp";
		}
	}
	function conparePassWord(pass, repassWord) {
		return pass == repassWord;
	}
}
