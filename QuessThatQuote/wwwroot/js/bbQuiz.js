var maxRound = 10;
var currentRound = 0;


var quote = "";
var author = "";

function updateQuote() {
    $.ajax({
        url: '@Url.Action("GetQuote", "BreakingBad")' + '?round=' + currentRound,
        type: 'GET',
        success: function (response) {
            //$('#quote').html(response);
            quote = response;
        }
    });
}

function updateAuthor() {
    $.ajax({
        url: '@Url.Action("GetAuthor", "BreakingBad")' + '?round=' + currentRound,
        type: 'GET',
        success: function (response) {
            //$('#author').html(response);
            author = response;

        }
    });
}
function displayCorrect() {

}


$("#optionA").on("click", function () {

    if (currentRound < maxRound) {
        currentRound++;

        nextRound();

    }


});

function nextRound() {
    updateQuote();
    updateAuthor();

    $('#quote').html(quote);
    $('#optionA').html("A - " + author)

}

$(document).ready(function () {
    nextRound()
});