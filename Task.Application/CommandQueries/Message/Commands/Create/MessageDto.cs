using AutoMapper;
using Task.Application.Common.Mappings;

namespace Task.Application.CommandQueries.Message.Commands.Create;

public class MessageDto : IMapWith<Domain.Message>
{
    public string Sender { get; set; }
    public string Recipient { get; set; }
    public DateTime Date { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Message, MessageDto>()
            .ForMember(c => c.Sender,
                o => o.MapFrom(c => c.Sender))
            .ForMember(c => c.Recipient,
                o => o.MapFrom(c => c.Recipient))
            .ForMember(c => c.Date,
                o => o.MapFrom(c => c.Date))
            .ForMember(c => c.Title,
                o => o.MapFrom(c => c.Title))
            .ForMember(c => c.Body,
                o => o.MapFrom(c => c.Body));
    }
}