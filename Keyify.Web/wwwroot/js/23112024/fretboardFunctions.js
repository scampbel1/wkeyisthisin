﻿function UpdateModel(url, scale, addNote, selectedNotes, lockScale) {
    var data = {
        PreviouslySelectedNotes: selectedNotes,
        NewlySelectedNote: addNote,
        SelectedScale: scale,
        LockScale: lockScale
    };
    fetchAndUpdateFretboard(url, data);
}

function Reset(url, scale, addNote, selectedNotes) {
    var data = {
        PreviouslySelectedNotes: selectedNotes,
        NewlySelectedNote: addNote,
        SelectedScale: scale,
        LockScale: false
    };
    fetchAndUpdateFretboard(url, data);
}

function ChangeInstrument(url, scale, selectedNotes, lockScale) {
    var data = {
        PreviouslySelectedNotes: selectedNotes,
        SelectedScale: scale,
        LockScale: lockScale
    };
    fetchAndUpdateFretboard(url, data);
}

function fetchAndUpdateFretboard(url, data) {
    var token = document.querySelector('input[name="__RequestVerificationToken"]').value;

    fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            "Access-Control-Origin": "*",
            "RequestVerificationToken": token
        },
        body: JSON.stringify(data)
    })
        .then(response => {
            if (response.ok) {
                return response.text();
            } else {
                throw new Error(`Error: ${response.status}`);
            }
        })
        .then(data => {
            document.getElementById("Fretboard").innerHTML = data;
        })
        .catch(error => {
            console.error(error);
        });
}

function copyContent(quickLinkCode) {
    var quickLinkUrl = document.location.protocol + "//" + document.location.host + "/ql/v1/" + quickLinkCode;

    navigator.clipboard.writeText(quickLinkUrl)
        .then(() => {
            console.log('Quick Link copied to clipboard');
        })
        .catch(err => {
            console.error('Failed to copy Quick Link: ', err);
        });
}