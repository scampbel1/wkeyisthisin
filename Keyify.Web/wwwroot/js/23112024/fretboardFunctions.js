// This worked last time...
//var dataPost = new FormData();
//dataPost.append('previouslySelectedNotes', JSON.stringify(selectedNotes));
//dataPost.append('newlySelectedNote', addNote);
//dataPost.append('selectedScale', scale);
//dataPost.append('lockScale', lockScale);

//var headers = {
//    "Content-Type": "application/json",
//    "Access-Control-Origin": "*"
//}
//headers: headers,

function UpdateModel(url, scale, addNote, selectedNotes, lockScale) {
    var dataPost = {
        PreviouslySelectedNotes: selectedNotes,
        NewlySelectedNote: addNote,
        SelectedScale: scale,
        LockScale: lockScale
    };

    fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            "Access-Control-Origin": "*"
        },
        body: JSON.stringify(dataPost),
    })
        .then(response => {
            if (response.ok) {
                return response.text();
            } else {
                throw new Error('Error:', response.status);
            }
        })
        .then(data => {
            console.log('Received HTML!');
            const fretboardElement = document.getElementById("Fretboard");
            if (fretboardElement) {
                fretboardElement.innerHTML = data;
            } else {
                console.error("Could not find #Fretboard element");
            }
        })
        .catch(error => {
            console.error(error);
        });
}

async function Reset(url, scale, addNote, selectedNotes) {

    var dataPost = {
        PreviouslySelectedNotes: selectedNotes,
        NewlySelectedNote: addNote,
        SelectedScale: scale,
        LockScale: false
    };

    try {
        const response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(dataPost)
        });

        if (response.ok) {
            const data = await response.text();
            document.getElementById("Fretboard").innerHTML = data;
        } else {
            console.error('Error:', response.status);
        }
    } catch (error) {
        console.error(error);
    }
}

async function ChangeInstrument(url, scale, selectedNotes, lockScale) {

    var dataPost = {
        PreviouslySelectedNotes: selectedNotes,
        SelectedScale: scale,
        LockScale: lockScale
    };

    try {
        const response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(dataPost)
        });

        if (response.ok) {
            const data = await response.text();
            document.getElementById("Fretboard").innerHTML = data;
        } else {
            console.error('Error:', response.status);
        }
    } catch (error) {
        console.error(error);
    }
}

async function copyContent(quickLinkCode) {
    try {
        var quickLinkUrl = document.location.protocol + "//" + document.location.host + "/ql/v1/" + quickLinkCode;

        await navigator.clipboard.writeText(quickLinkUrl);

        console.log('Quick Link copied to clipboard');
    } catch (err) {
        console.error('Failed to copy Quick Link: ', err);
    }
}