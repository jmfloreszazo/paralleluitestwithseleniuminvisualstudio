// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let counter = 0;
function counterClicks() {
    counter++;
    $('#textCounter').val(counter);
}