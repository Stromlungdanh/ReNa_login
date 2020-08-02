using System.Collections.Generic;
using Framework.Chat.Dto;
using Framework.Dto;

namespace Framework.Chat.Exporting
{
    public interface IChatMessageListExcelExporter
    {
        FileDto ExportToFile(List<ChatMessageExportDto> messages);
    }
}
