using System;
using FluentValidation;

namespace ELibrary.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {

        public UpdateBookCommandValidator()
        {
            RuleFor(bookCommand => bookCommand.Name).NotEmpty().MaximumLength(30);

            RuleFor(bookCommand => bookCommand.BriefDescription).NotEmpty().MaximumLength(50);

            RuleFor(bookCommand => bookCommand.FullDescription).NotEmpty().MaximumLength(120);

            RuleFor(bookCommand => bookCommand.OriginallyPublishedAt.Year)
                .LessThanOrEqualTo(DateTime.Now.Year); // Feel like it is very bad
        }
    }
}