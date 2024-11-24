function UpdateModel(url, scale, addNote, selectedNotes, lockScale) {
    fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            "Access-Control-Origin": "*"
        },
        body: JSON.stringify({
            PreviouslySelectedNotes: selectedNotes,
            NewlySelectedNote: addNote,
            SelectedScale: scale,
            LockScale: lockScale
        }),
    })
        .then(response => response.ok ? response.text() : Promise.reject(response.status))
        .then(data => document.getElementById("Fretboard").innerHTML = data)
        .catch(error => console.error(error));
}

async function Reset(url, scale, addNote, selectedNotes) {
    try {
        const response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                PreviouslySelectedNotes: selectedNotes,
                NewlySelectedNote: addNote,
                SelectedScale: scale,
                LockScale: false
            })
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
    try {
        const response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                PreviouslySelectedNotes: selectedNotes,
                SelectedScale: scale,
                LockScale: lockScale
            })
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