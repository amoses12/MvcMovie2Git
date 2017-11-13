//app.factory('MoviesTable') function($scope, $http) {
//    var app = angular.module("MyMovieApp", []);
//    app.controller("MovieAngularController", function ($scope, $http) {
//        $scope.myMovies = [];
//        $scope.setMovies = function () {
//            $http({ method: "SET", url: "/Movies/GetMovies" }).then(function (data) {
//                $scope.myMovies = data.data; //api call
//                console.log($scope.myMovies);
//            })
//        };
//        $scope.setMovies();
//    });
//}

app.filter('unique', function () {
    return function (collection, keyname) {
        var output = [];
        byGenreList = [];

        angular.forEach(collection, function (item) {
            var genre = item[keyname];

            // look up indexOf
            if (genre === item.genre) {
                byGenrelist.push(item);


                output.push(item);
            }
        });

        return output;

    };
});