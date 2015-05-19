angular.module('ComplejoController', []).controller('ComplejoCtrl', ['$scope', '$http', function ($scope, $http) {

    $scope.ListaComplejo = {};
    $scope.Registro = {};
    $scope.Accion = 'nuevo';
    $scope.MostrarControles = false;


    $scope.Limpiar = function () {
        $scope.Registro = {};
        $scope.Accion = 'nuevo';
        $scope.MostrarControles = false;
    };

    $scope.NuevoRegistro = function () {
        $scope.Registro = {};
        $scope.Accion = 'nuevo';
        $scope.MostrarControles = true;
    };

    $scope.EditarRegistro = function (registroEditar) {
        $scope.Registro = registroEditar;
        $scope.Accion = 'editar';
        $scope.MostrarControles = true;
    }

    $http.get('/Complejo/GetAll').success(function (data) {
        $scope.ListaComplejo = data;
    });
    

    $scope.Guardar = function () {
        if ($scope.Accion == 'nuevo') {
            $http.post('/Complejo/Create', $scope.Registro).success(function (data) {
                $scope.ListaComplejo.push(data);
            });
        }

        if ($scope.Accion == 'editar') {
            $http.post('/Complejo/Update', $scope.Registro).success(function (data) {
                // $scope.ListaCanchas.push(data);
            });
        }

        $scope.Limpiar();
    }


    $scope.EliminarRegistro = function (registroEliminar) {
        var response = $http({
            method: "post",
            url: "/Complejo/Delete",
            params: { id: JSON.stringify(registroEliminar.ID) }
        });

        var indice = $scope.ListaComplejo.indexOf(registroEliminar);

        $scope.ListaComplejo.splice(indice, 1);

    }




}

]);