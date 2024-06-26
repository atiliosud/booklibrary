﻿using System;
using BookLibrary.Commands;
using BookLibrary.Entities;
using BookLibrary.Repositories;
using MediatR;

namespace BookLibrary.EventHandlers
{
    public class CreateBookHandler : IRequestHandler<CreateBook, Book>
    {
        private readonly IRepository<Book> repositoryBook;

        public CreateBookHandler(IRepository<Book> repositoryBook)
        {
            this.repositoryBook = repositoryBook;
        }

        public async Task<Book> Handle(CreateBook request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Title = request.Title,
                FirstName = request.FirstName,
                LastName = request.LastName,
                TotalCopies = request.TotalCopies,
                CopiesInUse = request.CopiesInUse,
                Type = request.Type,
                Isbn = request.Isbn,
                Category = request.Category,
            };
            await repositoryBook.AddAsync(book);
            return book;
        }
    }
}
