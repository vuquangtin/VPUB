var app = angular.module('emailapp', []);
app.controller('emailController', email);
var link = '/smeetingregister/sworld'
function email($scope, $http) {
	var dataType = {
		dataType : "json"
	};
	var config = {
		headers : {
			'Content-Type' : 'application/json;charset=utf-8;'
		}
	};
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
					$scope.informessageadd = "Cấu hình thành công!";
				} else {
					$scope.informessageadd = "Thêm mới thất bại!";
				}
			}, _error);
		} else {
			$scope.validate = "Mật khẩu không khớp";
		}
	}
	function conparePassWord(pass, repassWord) {
		return pass == repassWord;
	}
	function _error(response) {
		console.log(response.statusText);
	}
}