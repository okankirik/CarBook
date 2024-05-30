using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Testimonials.Mediator.Handlers.TestimonialHandlers;

public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
{
    private readonly IRepository<Testimonial> _repository;

    public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
    {
        _repository = repository;
    }
    public async Task<Unit> Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        value.Id = request.Id;
        value.Name = request.Name;
        value.Comment = request.Comment;
        value.Title = request.Title;
        value.ImageUrl = request.ImageUrl;
        await _repository.UpdateAsync(value);
        return Unit.Value;
    }
}
