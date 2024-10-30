using System;

namespace AceLand.Library.Optional
{
    public static class OptionalExtensions
    {
        public static Option<T> ToOption<T>(this T? obj) where T : class =>
            obj is null ? Option<T>.None() : Option<T>.Some(obj);

        public static Option<T> Where<T>(this T? obj, Func<T, bool> predicate) where T : class =>
            obj is not null && predicate(obj) ? Option<T>.Some(obj) : Option<T>.None();

        public static Option<T> WhereNot<T>(this T? obj, Func<T, bool> predicate) where T : class =>
            obj is not null && !predicate(obj) ? Option<T>.Some(obj) : Option<T>.None();
        
        public static ValueOption<T> ToValueOption<T>(this T obj) where T : struct =>
            ValueOption<T>.Some(obj);

        public static ValueOption<T> WhereValue<T>(this T obj, Func<T, bool> predicate) where T : struct =>
            predicate(obj) ? ValueOption<T>.Some(obj) : ValueOption<T>.None();

        public static ValueOption<T> WhereValueNot<T>(this T obj, Func<T, bool> predicate) where T : struct =>
            !predicate(obj) ? ValueOption<T>.Some(obj) : ValueOption<T>.None();
    }
}
