// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

        function showModalPopupAnnuleren() {
            $('#annulerenModal').modal('show');
        }
    

        $(document).ready(function () {
            $('#annulerenModal').on('click', '.btn-secondary', function () {
                $('#annulerenModal').modal('hide');
            });
        });

        function showModalPopupDisable() {
            $('#disableModal').modal('show');
        }
        $(document).ready(function () {
            $('#disableModal').on('click', '.btn-secondary', function () {
                $('#disableModal').modal('hide');
            });
        });

        function showModalPopupActivate() {
            // Modern way to open a modal popup using Bootstrap
            $('#activateModal').modal('show');
        }
        $(document).ready(function () {
            $('#activateModal').on('click', '.btn-secondary', function () {
                $('#activateModal').modal('hide');
            });
        });
