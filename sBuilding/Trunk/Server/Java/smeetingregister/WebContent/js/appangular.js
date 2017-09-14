var app = angular.module('myApp', []);
app.controller('Mycontroller', login);
var link = '/smeetingregister/sworld'
function login($scope, $http) {
	$scope.login = function() {
		$scope.validate = "Đang đăng nhập...!";
		var username = $scope.username;
		var password = $scope.password;
		$http.get(link + '/acount/login/' + username + '/' + password).then(
				function(response) {
					if (response.data.status == "SUCCESS") {
						window.location = "detailmeeting.html";
					} else {
						$scope.validate = "Sai thông tin đăng nhập!";
					}
				}, function errorCallback(response) {
					console.log(response.statusText);
				});
	}
	$scope.save = function() {
		var username = $scope.username;
		var email = $scope.email;
		var passWord = $scope.password;
		var repassWord = $scope.repassword;
		var dataObj = {
			"id" : 0,
			"name" : $scope.name,
			"userName" : username,
			"email" : email,
			"passWord" : passWord
		};
		var dataType = {
			dataType : "json"
		};
		var config = {
			headers : {
				'Content-Type' : 'application/json;charset=utf-8;'
			}
		};
		var res = $http
				.post(link + '/acount/insert', dataObj, dataType, config);
		res.then(function(response) {
			if (response.data.status == "SUCCESS") {
				$scope.name = "";
				$scope.username ="";
				$scope.password = "";
				$scope.email = "";
				$scope.repassword = "";
				$scope.informessageadd = "Thêm mới thành công!";
			} else {
				$scope.informessageadd = "Thêm mới thất bại!";
			}
		}, _error);

	}
	// function _success(response) {
	// _clearFormData();
	// }
	//
	function _error(response) {
		console.log(response.statusText);
	}
	// // Clear the form
	// function _clearFormData() {
	// $scope.name = "";
	// $scope.username = "";
	// $scope.password
	// "";
	// $scope.email = "";
	// $scope.repassword = "";
	//
	// }
};
