'use strict';

/* Controllers */

angular.module('myApp.factories', []).factory('Student', ['$resource', function ($resource) {
    var resource = $resource('http://localhost:61014/api/student', {}, { get: { method: 'GET', isArray: true } });
    return resource;
}
]);

angular.module('myApp.controllers', [])
    .controller('MyCtrl1', ['$scope', 'Student', function ($scope, Student) {
        $scope.students = [];
        Student.get(function (response) {
            $scope.students = response;
        });


    }
    ])
    .controller('MyCtrl2', ['$scope', 'Student', function ($scope, Student) {

        $scope.students = [];
        $scope.name = '';
        $scope.phone = '';
        $scope.address = '';

        $scope.save = function () {
            Student.save({ Name: $scope.name, Phone: $scope.phone, Address: $scope.address },
                function (response) {
                    if (response) {
                        $scope.noftify = "Student save Successfully";
                    } else {
                        $scope.noftify = "failed to save";

                    }
                });
        }
    }]);
