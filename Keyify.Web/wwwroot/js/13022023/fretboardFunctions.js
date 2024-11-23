async function UpdateModel(url, scale, addNote, selectedNotes, lockScale) {

    var dataPost = {
        previouslySelectedNotes: selectedNotes,
        newlySelectedNote: addNote,
        selectedScale: scale,
        lockScale: lockScale
    };

    try {
        const response = await $.ajax({
            url: url,
            type: "POST",
            data: dataPost,
            datatype: "json"
        });

        $("#Fretboard").html(response);
    } catch (error) {
        console.error(error);
    }
}

async function Reset(url, scale, addNote, selectedNotes) {

    var dataPost = {
        previouslySelectedNotes: selectedNotes,
        newlySelectedNote: addNote,
        selectedScale: scale
    };

    try {
        const response = await $.ajax({
            url: url,
            type: "POST",
            data: dataPost,
            datatype: "json"
        });

        $("#Fretboard").html(response);
    } catch (error) {
        console.error(error);
    }
}

async function ChangeInstrument(url, scale, selectedNotes) {

    var dataPost = {
        previouslySelectedNotes: selectedNotes,
        selectedScale: scale
    };

    try {
        const response = await $.ajax({
            url: url,
            type: "POST",
            data: dataPost,
            datatype: "json"
        });

        $("#Fretboard").html(response);
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