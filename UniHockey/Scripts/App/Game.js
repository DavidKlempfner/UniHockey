window.onload = setupEventHandlers;

function setupEventHandlers() {
    setupEventHandlersForTextboxes('Team1PlayerScores', 'Team1_GoalsForCurrentGame');
    setupEventHandlersForTextboxes('Team2PlayerScores', 'Team2_GoalsForCurrentGame');

    var clearAllFieldsButton = document.getElementById('ClearAllFields');
    clearAllFieldsButton.setAttribute('onclick', "resetTextboxes()");
}

function setupEventHandlersForTextboxes(teamPlayerScoresDivId, teamScoreTextboxId) {
    var team1PlayerScoresDiv = document.getElementById(teamPlayerScoresDivId);
    var textboxes = team1PlayerScoresDiv.getElementsByTagName('input');
    for (var i = 0; i < textboxes.length; i++) {
        if (textboxes[i].type == 'number') {
            textboxes[i].setAttribute('onchange', "updateTeamScore('" + teamPlayerScoresDivId + "', '" + teamScoreTextboxId + "')");
        }
    }  
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

function resetTextboxes() {
    var elements = document.getElementsByTagName('input');
    for (var i = 0; i < elements.length; i++) {
        if (elements[i].type == 'number') {
            elements[i].value = '0';
        }
    }
}