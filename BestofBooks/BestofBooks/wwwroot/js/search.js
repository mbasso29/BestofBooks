// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/* Add event listener to Inventory Search buttons */
document.getElementById("SearchBtn").addEventListener("click", function () {
    clearInput("textFilter");
    resetSelect("searchOptions");
})

