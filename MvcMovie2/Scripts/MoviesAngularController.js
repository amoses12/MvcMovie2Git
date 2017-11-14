var MyMovieApp = angular.module('MyMovieApp', []);
MyMovieApp.factory('MyMovieAppFactory', function($http) {
    var myMovies = [];
 
        var getMovies = function () {
            debugger
            $http({ method: "GET", url: "/Movies/GetMovies" })
                .then(function (data) {
                myMovies = data.data; //api call
                //console.log($scope.myMovies[0]["ReleaseDate"]);
                // var list = $scope.myMovies;
                //for (i = 0; i <= myMovies.length - 1; i++) {
                //        debugger
                //        var milli = myMovies[i]["ReleaseDate"];
                //        console.log(milli);
                //        var result = milli.replace(/\/Date\((-?\d+)\)\//, '$1');
                //        var dateFormat = new Date(parseInt(result));
                //        myMovies[i]["ReleaseDate"] = dateFormat;
                //    }
                });
        };
    return myMovies;
    console.log(myMovies);

});

function MyMovieAppController($scope, MyMovieAppFactory) {
    debugger
    $scope.myMovies = MyMovieAppFactory.getMovies;
    
  
};
MyMovieApp.filter('unique', function () {
    return function (collection, keyname) {
        var output = [];
        keys = [];

        angular.foreach(collection, function (item) {
            var key = item[keyname];

            if (keys.indexof(key) === -1) {
                keys.push(key);


                output.push(item);
            }
        });

        return output;

    }
});


//angular.module('MyMovieApp', []).controller('MoviesAngularController', function ($scope, $http, getDataService) {
//    $scope.SearchFilter = function (Movies, movieGenre) {
//        $scope.FilterResult = [];
//        getDataService.getData(function (data) {
//            $scope.FilterResult = data.data;
//        });
//    }
//});


//        }
//    }
//});

//angular.forEach($scope.FilterResult, function (value, key1, key2) {
//    scope.results = [];
//    scope.filterSearchResult = function (Movies, movieGenre) {
//        angular.forEach($scope.myMovies.movie, function (value, key) {
//            if (Movies != null && movieGenre == null) {
//                if (key1 == Movie) {
//                    $scope.results.push(movie)
//                }
//            }
//        }

//     };
//});