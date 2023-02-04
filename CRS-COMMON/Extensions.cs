using CRS_DTOS.AdminDtos;
using CRS_DTOS.CourseCatalogDtos;
using CRS_DTOS.CourseDtos;
using CRS_DTOS.DepartmentDtos;
using CRS_DTOS.MajorDtos;
using CRS_DTOS.PaymentDtos;
using CRS_DTOS.PaymentMethodDtos;
using CRS_DTOS.ProfessorCoursesDtos;
using CRS_DTOS.ProfessorDtos;
using CRS_DTOS.RegisteredCourseDtos;
using CRS_DTOS.RegistrationStatusDtos;
using CRS_DTOS.RoleDtos;
using CRS_DTOS.SemesterRegistrationDtos;
using CRS_DTOS.StudentDtos;
using CRS_DTOS.UserDtos;
using CRS_MODELS;
using Newtonsoft.Json;

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

        public static ProfessorDto AsDto(this Professors professor)
        {
            return new ProfessorDto()
            {
                ProfessorId = professor.ProfessorId,
                ProfessorName = professor.ProfessorName,
                UserId = professor.UserId,
                DepartmentId = professor.DepartmentId,
                Email = professor.Email,
                Address = professor.Address,
                Phone = professor.Phone,
                UUID = professor.UUID,
                CreateDateTime = professor.CreateDateTime
            };
        }

        public static StudentDto AsDto(this Students student)
        {
            return new StudentDto()
            {
                StudentId = student.StudentId,
                StudentName = student.StudentName,
                UserId = student.UserId,
                MajorId = student.MajorId,
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

        public static CourseDto AsDto(this Courses course)
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

        public static CourseCatalogDto AsDto(this CourseCatalogs courseCatalog)
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

        public static PaymentMethodDto AsDto(this PaymentMethods paymentMethod)
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

        public static MajorDto AsDto(this Majors major)
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

        public static RoleDto AsDto(this Roles role)
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

        public static DepartmentDto AsDto(this Departments department)
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

        public static RegistrationStatusDto AsDto(this RegistrationStatus registrationStatus)
        {
            return new RegistrationStatusDto()
            {
                RegistrationStatusId = registrationStatus.RegistrationStatusId,
                RegistrationStatusName = registrationStatus.RegistrationStatusName,
                Description = registrationStatus.Description,
                UUID = registrationStatus.UUID,
                CreateDateTime = registrationStatus.CreateDateTime
            };
        }

        public static DateTime AsUiFormat(this DateTime date)
        {
            return DateTime.Parse($"{date.Month}/{date.Day}/{date.Year}");
        }

        public static string AsJsonString(this object entity)
        {
            return JsonConvert.SerializeObject(entity, Formatting.Indented);
        }

        public static T? AsJsonObject<T>(this string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
