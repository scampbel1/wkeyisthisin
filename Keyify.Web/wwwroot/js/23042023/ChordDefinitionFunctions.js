const textBoxPrototype = {
    htmlFieldName: undefined,
    fieldName: undefined,
    validate: validateTextBox
};

const intervalSelectionPrototype = {
    intervals: [],
    htmlFieldName: undefined,
    validate: validateIntervalArray
};

const nameTextBox = createNameTextBox();
const intervalsSelection = createInvervalsSelection();

function createNameTextBox() {
    //Example of "prototypal inheritence" - the "dynamic language version of classical inheritance"
    //See: "You Don't Know JS - this & Object Prototypes" - Page 93.
    let nameTextBox = Object.create(textBoxPrototype);

    nameTextBox.fieldName = "Chord Definition Name";
    nameTextBox.htmlFieldName = "chordDefinitionName";

    return nameTextBox;
}

function createInvervalsSelection() {
    var intervalsSelection = Object.create(intervalSelectionPrototype);

    intervalsSelection.htmlFieldName = "chordIntervals";

    return intervalsSelection;
}

function addInterval(button) {
    let interval = button.innerText;
    let intervalValue = button.value;

    intervalsSelection.intervals.push(intervalValue);
    updateIntervalsLabel(interval);

    console.log(intervalsSelection.intervals);
}

function updateIntervalsLabel(interval) {
    let intervalLabelText = document.getElementById(intervalsSelection.htmlFieldName);

    let newInterval = `${interval}`;

    if (intervalLabelText.innerHTML != '') {
        newInterval = `-${interval}`;
    }

    intervalLabelText.innerHTML += newInterval;

    console.log(intervalLabelText.innerHTML);
}

function submitChordDefinitionProposal() {

    let validationResult = validateFields();

    if (validationResult) {

        let inserted;
        let errorMessage;

        let name = document.getElementById(nameTextBox.htmlFieldName).value;
        let intervals = intervalsSelection.intervals;

        submitProposal(name, intervals)
            .then((data) => {
                console.log(data);

                inserted = data.wasInserted;
                errorMessage = data.errorMessage;
            }).then(() => {
                if (inserted == false) {
                    alert(errorMessage);
                }
                else {
                    alert("Chord definition submitted successfully.");
                    clearAll();
                }
            });
    }
}

function validateFields() {
    let isNameValid = nameTextBox.validate();
    let isIntervalSelectionValid = intervalsSelection.validate();

    if (isNameValid && isIntervalSelectionValid) {
        return true;
    }
    else {
        return false;
    }
}

function clearAll() {
    clearTextbox.call(nameTextBox);
    clearIntervalsArray.call(intervalsSelection);
    clearIntervalsLabel();
}

function clearIntervalsArray() {
    let intervals = this.intervals;

    if (intervals != null && intervals != undefined && intervals.length > 0) {
        console.log(`Clearing intervals array: ${intervals}`);

        intervals.splice(0, intervals.length);
        console.log(intervals);
    }
}

function clearIntervalsLabel() {
    let intervalLabelText = document.getElementById(intervalsSelection.htmlFieldName);

    intervalLabelText.innerHTML = "";
}

function validateTextBox() {

    let fieldName = this.fieldName;
    let fieldValue = document.getElementById(this.htmlFieldName).value;

    console.log(`${fieldName} - '${fieldValue}'`);

    if (fieldValue == undefined || fieldValue == null || fieldValue == '') {
        let message = `Warning '${fieldValue}' is not a valid value for '${fieldName}'.`;

        console.warn(message);
        alert(message);

        return false;
    }

    return true;
}

function clearTextbox() {
    document.getElementById(this.htmlFieldName).value = '';
}

function validateIntervalArray() {
    if (this.intervals != null && this.intervals.length > 0) {
        console.log("Interval selection valid");
        return true;
    }

    console.warn("Interval selection validation failed.");
    return false;
}

async function submitProposal(name, intervals) {
    let url = `${getCurrentUrl()}/ChordDefinition/Submit/`;

    alert(url);

    let chordDefinitionCheckRequest = {
        name: name,
        intervals: intervals
    };

    console.log(chordDefinitionCheckRequest)

    let response = await fetch(url,
        {
            method: 'POST',
            headers:
            {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(chordDefinitionCheckRequest)
        });

    return response.json();
}


//TODO: Move this out to it's own file - figure out how to structure these common functions
function getCurrentUrl() {
    let hostName = window.location.hostname;

    if (hostName === "localhost") {
        return `https://${hostName}:${window.location.port}`;
    }

    return `https://${hostName}`;
}