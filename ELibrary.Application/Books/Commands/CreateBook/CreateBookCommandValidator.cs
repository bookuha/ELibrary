using System;
using FluentValidation;

namespace ELibrary.Application.Books.Commands.CreateBook
{
    internal class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(bookCommand => bookCommand.Name).NotEmpty().MaximumLength(30);

            RuleFor(bookCommand => bookCommand.BriefDescription).NotEmpty().MaximumLength(50);

            RuleFor(bookCommand => bookCommand.FullDescription).NotEmpty().MaximumLength(120);

            RuleFor(bookCommand => bookCommand.OriginallyPublishedAt.Year)
                .LessThan(DateTime.Now.Year); // Feel like it is very bad

            // TODO: Finish here
        }
    }
}