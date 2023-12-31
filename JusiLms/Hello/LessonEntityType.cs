﻿// <auto-generated />
using System;
using System.Reflection;
using JusiLms.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;

#pragma warning disable 219, 612, 618
#nullable disable

namespace JusiLms.Hello
{
    internal partial class LessonEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "JusiLms.Models.Lesson",
                typeof(Lesson),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(Guid),
                propertyInfo: typeof(Lesson).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Lesson).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueGenerated: ValueGenerated.OnAdd,
                afterSaveBehavior: PropertySaveBehavior.Throw,
                sentinel: new Guid("00000000-0000-0000-0000-000000000000"));
            id.TypeMapping = GuidTypeMapping.Default.Clone(
                comparer: new ValueComparer<Guid>(
                    (Guid v1, Guid v2) => v1 == v2,
                    (Guid v) => v.GetHashCode(),
                    (Guid v) => v),
                keyComparer: new ValueComparer<Guid>(
                    (Guid v1, Guid v2) => v1 == v2,
                    (Guid v) => v.GetHashCode(),
                    (Guid v) => v),
                providerValueComparer: new ValueComparer<Guid>(
                    (Guid v1, Guid v2) => v1 == v2,
                    (Guid v) => v.GetHashCode(),
                    (Guid v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "uuid"));
            id.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);

            var categoryId = runtimeEntityType.AddProperty(
                "CategoryId",
                typeof(Guid),
                propertyInfo: typeof(Lesson).GetProperty("CategoryId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Lesson).GetField("<CategoryId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                sentinel: new Guid("00000000-0000-0000-0000-000000000000"));
            categoryId.TypeMapping = GuidTypeMapping.Default.Clone(
                comparer: new ValueComparer<Guid>(
                    (Guid v1, Guid v2) => v1 == v2,
                    (Guid v) => v.GetHashCode(),
                    (Guid v) => v),
                keyComparer: new ValueComparer<Guid>(
                    (Guid v1, Guid v2) => v1 == v2,
                    (Guid v) => v.GetHashCode(),
                    (Guid v) => v),
                providerValueComparer: new ValueComparer<Guid>(
                    (Guid v1, Guid v2) => v1 == v2,
                    (Guid v) => v.GetHashCode(),
                    (Guid v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "uuid"));
            categoryId.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);

            var createdAt = runtimeEntityType.AddProperty(
                "CreatedAt",
                typeof(DateTime),
                propertyInfo: typeof(TimeStampedModel).GetProperty("CreatedAt", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(TimeStampedModel).GetField("<CreatedAt>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                sentinel: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            createdAt.TypeMapping = NpgsqlTimestampTzTypeMapping.Default.Clone(
                comparer: new ValueComparer<DateTime>(
                    (DateTime v1, DateTime v2) => v1.Equals(v2),
                    (DateTime v) => v.GetHashCode(),
                    (DateTime v) => v),
                keyComparer: new ValueComparer<DateTime>(
                    (DateTime v1, DateTime v2) => v1.Equals(v2),
                    (DateTime v) => v.GetHashCode(),
                    (DateTime v) => v),
                providerValueComparer: new ValueComparer<DateTime>(
                    (DateTime v1, DateTime v2) => v1.Equals(v2),
                    (DateTime v) => v.GetHashCode(),
                    (DateTime v) => v));
            createdAt.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);

            var description = runtimeEntityType.AddProperty(
                "Description",
                typeof(string),
                propertyInfo: typeof(Lesson).GetProperty("Description", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Lesson).GetField("<Description>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            description.TypeMapping = StringTypeMapping.Default.Clone(
                comparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                keyComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    dbType: System.Data.DbType.String));
            description.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);

            var header = runtimeEntityType.AddProperty(
                "Header",
                typeof(string),
                propertyInfo: typeof(Lesson).GetProperty("Header", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Lesson).GetField("<Header>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            header.TypeMapping = StringTypeMapping.Default.Clone(
                comparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                keyComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    dbType: System.Data.DbType.String));
            header.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);

            var lastModified = runtimeEntityType.AddProperty(
                "LastModified",
                typeof(DateTime?),
                propertyInfo: typeof(TimeStampedModel).GetProperty("LastModified", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(TimeStampedModel).GetField("<LastModified>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            lastModified.TypeMapping = NpgsqlTimestampTzTypeMapping.Default.Clone(
                comparer: new ValueComparer<DateTime?>(
                    (Nullable<DateTime> v1, Nullable<DateTime> v2) => v1.HasValue && v2.HasValue && (DateTime)v1 == (DateTime)v2 || !v1.HasValue && !v2.HasValue,
                    (Nullable<DateTime> v) => v.HasValue ? ((DateTime)v).GetHashCode() : 0,
                    (Nullable<DateTime> v) => v.HasValue ? (Nullable<DateTime>)(DateTime)v : default(Nullable<DateTime>)),
                keyComparer: new ValueComparer<DateTime?>(
                    (Nullable<DateTime> v1, Nullable<DateTime> v2) => v1.HasValue && v2.HasValue && (DateTime)v1 == (DateTime)v2 || !v1.HasValue && !v2.HasValue,
                    (Nullable<DateTime> v) => v.HasValue ? ((DateTime)v).GetHashCode() : 0,
                    (Nullable<DateTime> v) => v.HasValue ? (Nullable<DateTime>)(DateTime)v : default(Nullable<DateTime>)),
                providerValueComparer: new ValueComparer<DateTime?>(
                    (Nullable<DateTime> v1, Nullable<DateTime> v2) => v1.HasValue && v2.HasValue && (DateTime)v1 == (DateTime)v2 || !v1.HasValue && !v2.HasValue,
                    (Nullable<DateTime> v) => v.HasValue ? ((DateTime)v).GetHashCode() : 0,
                    (Nullable<DateTime> v) => v.HasValue ? (Nullable<DateTime>)(DateTime)v : default(Nullable<DateTime>)));
            lastModified.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);

            var youtubeUrl = runtimeEntityType.AddProperty(
                "YoutubeUrl",
                typeof(string),
                propertyInfo: typeof(Lesson).GetProperty("YoutubeUrl", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Lesson).GetField("<YoutubeUrl>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            youtubeUrl.TypeMapping = StringTypeMapping.Default.Clone(
                comparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                keyComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    dbType: System.Data.DbType.String));
            youtubeUrl.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);

            var key = runtimeEntityType.AddKey(
                new[] { id });
            runtimeEntityType.SetPrimaryKey(key);

            var index = runtimeEntityType.AddIndex(
                new[] { categoryId });

            return runtimeEntityType;
        }

        public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("CategoryId") },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id") }),
                principalEntityType,
                deleteBehavior: DeleteBehavior.Cascade,
                required: true);

            var category = declaringEntityType.AddNavigation("Category",
                runtimeForeignKey,
                onDependent: true,
                typeof(Category),
                propertyInfo: typeof(Lesson).GetProperty("Category", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Lesson).GetField("<Category>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            return runtimeForeignKey;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "Lessons");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
