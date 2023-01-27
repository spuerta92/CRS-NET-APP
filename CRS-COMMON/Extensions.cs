﻿using CRS_DTOS.AdminDtos;
using CRS_DTOS.CourseDtos;
using CRS_DTOS.PaymentDtos;
using CRS_DTOS.ProfessorDtos;
using CRS_DTOS.StudentDtos;
using CRS_DTOS.UserDtos;
using CRS_MODELS;

namespace CRS_COMMON
{
    public static class Extensions
    {
        public static AdminDto AsDto(this Admin admin)
        {
            return new AdminDto()
            {
                AdminId = admin.AdminId,
                AdminName = admin.AdminName,
                Email = admin.Email,
                Address = admin.Address,
                Phone = admin.Phone,
                UUID = admin.UUID,
                CreateDateTime = admin.CreateDateTime
            };
        }

        public static ProfessorDto AsDto(this Professor professor)
        {
            return new ProfessorDto()
            {
                ProfessorId = professor.ProfessorId,
                ProfessorName = professor.ProfessorName,
                Email = professor.Email,
                Address = professor.Address,
                Phone = professor.Phone,
                UUID = professor.UUID,
                CreateDateTime = professor.CreateDateTime
            };
        }

        public static StudentDto AsDto(this Student student)
        {
            return new StudentDto()
            {
                StudentId = student.StudentId,
                StudentName = student.StudentName,
                Email = student.Email,
                Address = student.Address,
                Phone = student.Phone,
                UUID = student.UUID,
                CreateDateTime = student.CreateDateTime
            };
        }

        public static UserDto AsDto(this Users user)
        {
            return new UserDto()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Password = user.Password,
                RoleId = user.RoleId,
                UUID = user.UUID,
                CreateDateTime = user.CreateDateTime
            };
        }

        public static CourseDto AsDto(this Course course)
        {
            return new CourseDto()
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                Description = course.Description,
                UUID = course.UUID,
                CreateDateTime = course.CreateDateTime
            };
        }

        public static PaymentDto AsDto(this Payment payment)
        {
            return new PaymentDto()
            {
                PaymentId = payment.PaymentId,
                PaymentName = payment.PaymentName,
                StudentId = payment.StudentId,
                DueDate = payment.DueDate,
                Semester = payment.Semester,
                PaymentMethodId = payment.PaymentMethodId,
                IsPaid = payment.IsPaid,
                UUID = payment.UUID,
                CreateDateTime = payment.CreateDateTime
            };
        }
    }
}
