namespace KeyifyWebClient.Models.ViewModels
{
    public partial class InstrumentViewModel
    {
        private string GetAvailableKeysAndScalesLabel()
        {
            return $"{GetAvailableKeysLabel()} {GetAvailableScaleLabel()}";
        }

        //TODO: Remove biolerplate code
        private string GetAvailableKeysLabel()
        {
            var matchingScaleCount = _groupedScalesService.GetTotalKeyCount();

            switch (matchingScaleCount)
            {
                case 0:
                    return GetNoKeysFoundMessage();
                case 1:
                    return $"{matchingScaleCount} Matching Key";
                default:
                    return $"{matchingScaleCount} Matching Keys";
            }
        }

        private string GetNoKeysFoundMessage()
        {
            var selectedNoteCount = SelectedNotes.Count;

            if (selectedNoteCount <= 2)
                return $"";

            if (selectedNoteCount > 2)
                return "No Matching Keys";
            else
                return "";
        }

        private string GetAvailableScaleLabel()
        {
            var matchingScaleCount = _groupedScalesService.GetTotalScaleCount();

            switch (matchingScaleCount)
            {
                case 0:
                    return GetNoScalesFoundMessage();
                case 1:
                    return $"{matchingScaleCount} Matching Scale";
                default:
                    return $"{matchingScaleCount} Matching Scales";
            }
        }

        private string GetNoScalesFoundMessage()
        {
            var selectedNoteCount = SelectedNotes.Count;

            if (selectedNoteCount == 1)
                return $"Only {selectedNoteCount} Note Selected";
            else if (selectedNoteCount <= 2)
                return $"Only {selectedNoteCount} Notes Selected";

            if (selectedNoteCount > 2)
                return "No Matching Scales";
            else
                return "No Notes Selected";
        }
    }
}
