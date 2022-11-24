using AutoMapper;
using Task.Application.CommandQueries.Message.Commands.Create;
using Task.Application.Common.Mappings;

namespace Task.Mvc.Models;

public class MessageModel : IMapWith<CreateMessageCommand>
{
    public string Recipient { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<MessageModel, CreateMessageCommand>()
            .ForMember(u => u.Recipient,
                o => o.MapFrom(u => u.Recipient))
            .ForMember(u => u.Title,
                o => o.MapFrom(u => u.Title))
            .ForMember(u => u.Body,
                o => o.MapFrom(u => u.Body));
    }
}