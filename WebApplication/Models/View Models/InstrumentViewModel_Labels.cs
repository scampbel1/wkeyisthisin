namespace KeyifyWebClient.Models.ViewModels
{
    public partial class InstrumentViewModel
    {
        //TODO: Remove biolerplate code
        private string GetAvailableKeysLabel()
        {
            var matchingScaleCount = _groupedScalesService.GetTotalKeyCount();

            switch (matchingScaleCount)
            {
                case 0:
                    return GetNoKeysFoundMessage();
                case 1:
                    return $"{matchingScaleCount} Matching Key Found";
                default:
                    return $"{matchingScaleCount} Matching Keys Found";
            }
        }

        private string GetNoKeysFoundMessage()
        {
            var selectedNoteCount = SelectedNotes.Count;

            if (selectedNoteCount <= 2)
                return $"";

            if (selectedNoteCount > 2)
                return "No Matching Keys Found";
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
                    return $"{matchingScaleCount} Matching Scale Found";
                default:
                    return $"{matchingScaleCount} Matching Scales Found";
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
                return "No Matching Scales Found";
            else
                return "No Notes Selected";
        }
    }
}
