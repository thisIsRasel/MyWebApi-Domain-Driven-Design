﻿namespace Domain.AggregatesModel.BookAggregate
{
    public interface IBookWriteRepository
    {
        void Add(Book book);
    }
}