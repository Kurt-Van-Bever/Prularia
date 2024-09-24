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

        function showModalPopupDisable(id) {
            $('#disableModal-' + id).modal('show');
        }
        $(document).ready(function (id) {
            $('#disableModal-' + id).on('click', '.btn-secondary', function () {
                $('#disableModal-' + id).modal('hide');
            });
        });

        function showModalPopupActivate(id) {
            // Modern way to open a modal popup using Bootstrap
            $('#activateModal-' + id).modal('show');
        }
        $(document).ready(function (id) {
            $('#activateModal-' + id).on('click', '.btn-secondary', function () {
                $('#activateModal-' + id).modal('hide');
            });
        });


