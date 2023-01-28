﻿using CRS_DTOS.AdminDtos;
using CRS_DTOS.CourseCatalogDtos;
using CRS_DTOS.CourseDtos;
using CRS_DTOS.DepartmentDtos;
using CRS_DTOS.MajorDtos;
using CRS_DTOS.PaymentDtos;
using CRS_DTOS.PaymentMethodDtos;
using CRS_DTOS.ProfessorCoursesDtos;
using CRS_DTOS.ProfessorDtos;
using CRS_DTOS.RegisteredCourseDtos;
using CRS_DTOS.RoleDtos;
using CRS_DTOS.SemesterRegistrationDtos;
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

        public static CourseCatalogDto AsDto(this CourseCatalog courseCatalog)
        {
            return new CourseCatalogDto()
            {
                CourseCatalogId = courseCatalog.CourseCatalogId,
                CourseId = courseCatalog.CourseId,
                ProfessorId = courseCatalog.ProfessorId,
                DepartmentId = courseCatalog.DepartmentId,
                Prerequisite = courseCatalog.Prerequisite,
                Credits = courseCatalog.Credits,
                Capacity = courseCatalog.Capacity,
                Enrolled = courseCatalog.Enrolled,
                Semester = courseCatalog.Semester,
                UUID = courseCatalog.UUID,
                CreateDateTime = courseCatalog.CreateDateTime
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

        public static PaymentMethodDto AsDto(this PaymentMethod paymentMethod)
        {
            return new PaymentMethodDto()
            {
                PaymentMethodId = paymentMethod.PaymentMethodId,
                PaymentMethodName = paymentMethod.PaymentMethodName,
                Description = paymentMethod.Description,
                UUID = paymentMethod.UUID,
                CreateDateTime = paymentMethod.CreateDateTime
            };
        }

        public static MajorDto AsDto(this Major major)
        {
            return new MajorDto()
            {
                MajorId = major.MajorId,
                MajorName = major.MajorName,
                Description = major.Description,
                UUID = major.UUID,
                CreateDateTime = major.CreateDateTime
            };
        }

        public static RoleDto AsDto(this Role role)
        {
            return new RoleDto()
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
                Description = role.Description,
                UUID = role.UUID,
                CreateDateTime = role.CreateDateTime
            };
        }

        public static DepartmentDto AsDto(this Department department)
        {
            return new DepartmentDto()
            {
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName,
                Description = department.Description,
                UUID = department.UUID,
                CreateDateTime = department.CreateDateTime
            };
        }

        public static ProfessorCoursesDto AsDto(this ProfessorCourses professorCourses)
        {
            return new ProfessorCoursesDto()
            {
                ProfessorCoursesId = professorCourses.ProfessorCoursesId,
                ProfessorId = professorCourses.ProfessorId,
                CourseId = professorCourses.CourseId,
                UUID = professorCourses.UUID,
                CreateDateTime = professorCourses.CreateDateTime
            };
        }

        public static SemesterRegistrationDto AsDto(this SemesterRegistration semesterRegistration)
        {
            return new SemesterRegistrationDto()
            {
                RegistrationId = semesterRegistration.RegistrationId,
                StudentId = semesterRegistration.StudentId,
                ApprovalStatus = semesterRegistration.ApprovalStatus,
                AdminId = semesterRegistration.AdminId,
                Comment = semesterRegistration.Comment,
                UUID = semesterRegistration.UUID,
                CreateDateTime = semesterRegistration.CreateDateTime
            };
        }

        public static RegisteredCourseDto AsDto(this RegisteredCourse registeredCourse)
        {
            return new RegisteredCourseDto()
            {
                RegisteredCourseId = registeredCourse.RegisteredCourseId,
                StudentId = registeredCourse.StudentId,
                CourseId = registeredCourse.CourseId,
                RegistrationStatusId = registeredCourse.RegistrationStatusId,
                Grade = registeredCourse.Grade,
                UUID = registeredCourse.UUID,
                CreateDateTime = registeredCourse.CreateDateTime
            };
        }
    }
}
