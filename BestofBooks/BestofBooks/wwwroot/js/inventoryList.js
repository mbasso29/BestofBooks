﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


/*Need to add js for edit button to allow fields to be editable*/
function edit_row(no) {
    document.getElementById("edit_Pen" + no).style.display = "none";

    var ISBN = document.getElementById("invListISBN" + no);
    var Title = document.getElementById("invListTitle" + no);
    var AuthorFirst = document.getElementById("invListAuthorFirst" + no);
    var AuthorLast = document.getElementById("invListAuthorLast" + no);
    var Genre = document.getElementById("invListGenre" + no);
    var Location = document.getElementById("invListLocation" + no);
    var Price = document.getElementById("invListPrice" + no);
    var Qty = document.getElementById("invListQty" + no);

    var ISBN_data = ISBN.innerHTML;
    var title_data = Title.innerHTML;
    var authorFirst_data = AuthorFirst.innerHTML;
    var authorLast_data = AuthorLast.innerHTML;
    var genre_data = Genre.innerHTML;
    var location_data = Location.innerHTML;
    var price_data = Price.innerHTML;
    var qty_data = Qty.innerHTML;

    ISBN.innerHTML = "<input type='text' id='isbn_text" + no + "'value='" + ISBN_data + "'>"; 
    Title.innerHTML = "<input type='text' id='title_text" + no + "'value='" + title_data + "'>"; 
    AuthorFirst.innerHTML = "<input type='text' id='authorFirst_text" + no + "'value='" + authorFirst_data + "'>"; 
    AuthorLast.innerHTML = "<input type='text' id='authorLast_text" + no + "'value='" + authorLast_data + "'>"; 
    Genre.innerHTML = "<input type='text' id='genre_text" + no + "'value='" + genre_data + "'>"; 
    Location.innerHTML = "<input type='text' id='location_text" + no + "'value='" + location_data + "'>";
    Price.innerHTML = "<input type='text' id='price_text" + no + "'value='" + price_data + "'>";
    Qty.innerHTML = "<input type='text' id='qty_text" + no + "'value='" + qty_data + "'>";
}

function add_row() {
    var new_ISBN = document.getElementById("new_ISBN").value;
    var new_title = document.getElementById("new_title").value;
    var new_authorFirst = document.getElementById("new_authorFirst").value;
    var new_authorLast = document.getElementById("new_authorLast").value;
    var new_genre = document.getElementById("new_genre").value;
    var new_location = document.getElementById("new_location").value;
    var new_price = document.getElementById("new_price").value;
    var new_qty = document.getElementById("new_qty").value;

    var table = document.getElementById("ListTable")
    var table_len = (table.rows.length) - 1;
    var row = table.insertRow(table_len).outerHTML = "<tr id='row" + table_len + "'><td id='isbn_row" + table_len + "'>" + new_ISBN + "</td><td id='title_row" + table_len + "'>" + new_title + "</td><td id='authorFirst_row" + table_len + "'>" + new_authorFirst + "</td><td id='authorLast_row" + table_len + "'>" + new_authorLast + "</td><td id='genre_row" + table_len + "'>" + new_genre + "</td><td id='location_row" + table_len + "'>" + new_location + "</td><td id='price_row" + table_len + "'>" + new_price + "</td><td id='qty_row" + table_len + "'>" + new_qty + "</td><td><input type='button' id='edit_Pen" + table_len + "' value='Edit' class='edit' onclick='edit_row(" + table_len + ")style='color: green; text - align:center'></td></tr>";

    document.getElementById("new_ISBN").value = "";
    document.getElementById("new_title").value = "";
    document.getElementById("new_authorFirst").value = "";
    document.getElementById("new_authorLast").value = "";
    document.getElementById("new_genre").value = "";
    document.getElementById("new_location").value = "";
    document.getElementById("new_price").value = "";
    document.getElementById("new_qty").value = "";
}