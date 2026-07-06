using System;

namespace Exercise6_LibraryManagementSystem
{
    public class SearchLibrary
    {
        // Linear Search
        public static Book LinearSearch(Book[] books, string title)
        {
            foreach (Book book in books)
            {
                if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    return book;
                }
            }

            return null;
        }

        // Binary Search
        public static Book BinarySearch(Book[] books, string title)
        {
            int left = 0;
            int right = books.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                int comparison = string.Compare(
                    books[mid].Title,
                    title,
                    StringComparison.OrdinalIgnoreCase);

                if (comparison == 0)
                {
                    return books[mid];
                }
                else if (comparison < 0)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return null;
        }
    }
}