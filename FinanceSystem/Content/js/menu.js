var optionsMenu = document.getElementById("options-menu");
var moreButton = document.querySelector(".cell-more-button");

moreButton.addEventListener("click", function () {
    if (optionsMenu.style.display === "none") {
        optionsMenu.style.display = "block";
    } else {
        optionsMenu.style.display = "none";
    }
});
//$(document).ready(function () {
//    $('#

/*').click(function () {*/
//        var category = $('#categoryFilter').val(); // L?y gi� tr? c?a select option

//        // G?i y�u c?u ??n server b?ng Ajax
//        $.ajax({
//            url: '/Transactions/FilterByCategory', // ???ng d?n t?i action x? l� y�u c?u l?c
//            type: 'POST', // Ph??ng th?c HTTP
//            data: { category: category }, // Tham s? g?i ?i
//            success: function (result) {
//                // C?p nh?t l?i n?i dung tr�n trang
//                $('#transactionList').html(result);
//            },
//            error: function (xhr, status, error) {
//                console.log(error); // X? l� l?i n?u c�
//            }
//        });
//    });
//});

var dropdownButton = document.querySelector('.account-info-more');
var dropdown = document.querySelector('.dropdown');

dropdownButton.addEventListener('click', function () {
    dropdown.classList.toggle('open');
}); 

    //$('#filterButton').click(function () {
    //    var category = $('#categoryFilter').val(); // L?y gi� tr? c?a select option

    //    // G?i y�u c?u ??n server b?ng Ajax
    //    $.ajax({
    //        url: '../api/TransAPI/FilterByCategory', // ???ng d?n t?i action x? l� y�u c?u l?c
    //        type: 'GET', // Ph??ng th?c HTTP
    //        data: { category: category }, // Tham s? g?i ?i
    //        success: function (result) {
    //            // C?p nh?t l?i n?i dung tr�n trang
    //            $('#transactionList1').html(result);
    //        },
    //        error: function (xhr, status, error) {
    //            console.log(error); // X? l� l?i n?u c�
    //        }
    //    });
    //});
