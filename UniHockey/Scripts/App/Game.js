function incrementPlayerScore(playerId) {
    var currentPlayerScore = parseInt(document.getElementById(playerId).value);
    currentPlayerScore++;
    document.getElementById(playerId).value = currentPlayerScore;
}

function updateTeamScore(teamPlayerScoresDivId, teamScoreTextboxId) {
    var currentScore = addPlayersScores(teamPlayerScoresDivId);
    document.getElementById(teamScoreTextboxId).value = currentScore;
}

function addPlayersScores(teamPlayerScoresDivId) {
    var team1PlayerScoresDiv = document.getElementById(teamPlayerScoresDivId);
    var textboxes = team1PlayerScoresDiv.getElementsByTagName('input');
    var currentScore = 0;
    for (var i = 0; i < textboxes.length; i++) {
        if (textboxes[i].type == 'number') {
            currentScore += parseInt(textboxes[i].value);
        }
    }
    return currentScore;
}