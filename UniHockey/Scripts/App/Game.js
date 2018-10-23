//TODO: Get this unobtrusive JS to work:
//window.addEventListener("DOMContentLoaded", function (event) {
//    var team1PlayerScoresDiv = document.getElementById('Team1PlayerScores');
//    var textboxes = team1PlayerScoresDiv.getElementsByTagName("input");
//    for (var i = 0; i < textboxes.length; i++) {
//        if (textboxes[i].type == "number") {
//            textboxes[i].addEventListener("onchange", updateTeamScore('Team1PlayerScores', 'Team1_GoalsForCurrentGame'));
//        }
//    }
//});

function updateTeamScore(teamPlayerScoresDivId, teamScoreTextboxId) {
    var currentScore = addPlayersScores(teamPlayerScoresDivId);
    document.getElementById(teamScoreTextboxId).value = currentScore;
}

function addPlayersScores(teamPlayerScoresDivId) {
    var team1PlayerScoresDiv = document.getElementById(teamPlayerScoresDivId);
    var textboxes = team1PlayerScoresDiv.getElementsByTagName("input");
    var currentScore = 0;
    for (var i = 0; i < textboxes.length; i++) {
        if (textboxes[i].type == "number") {
            currentScore += parseInt(textboxes[i].value);
        }
    }
    return currentScore;
}

function resetTextboxes() {
    var elements = document.getElementsByTagName("input");
    for (var i = 0; i < elements.length; i++) {
        if (elements[i].type == "number") {
            elements[i].value = "0";
        }
    }
}