

namespace learndotnetfast_web_services.Services.Courses
{
    using AutoMapper;
    using System.Collections.Generic;
    using learndotnetfast_web_services.Common.Exceptions.Custom;
    using learndotnetfast_web_services.Entities;
    using learndotnetfast_web_services.Repositories.CourseModule;
    using learndotnetfast_web_services.DTOs;

    public class CourseModuleService : ICourseModuleService
    {
        private readonly ICourseModuleRepository _courseModuleRepository;
        private readonly IMapper _mapper;

        // Dependency injection via constructor
        public CourseModuleService(ICourseModuleRepository courseModuleRepository, IMapper mapper)
        {
            _courseModuleRepository = courseModuleRepository;
            _mapper = mapper;
        }

        public CourseModuleDTO GetCourseModuleById(int id)
        {
            var courseModule = _courseModuleRepository.FindById(id) ?? throw new ResourceNotFoundException($"Course module not found with id {id}");
            return _mapper.Map<CourseModuleDTO>(courseModule);
        }

        public CourseModuleDTO SaveCourseModule(CourseModuleDTO courseModuleDTO)
        {
            CheckForDuplicateCourseModule(courseModuleDTO);

            var courseModuleToSave = _mapper.Map<CourseModule>(courseModuleDTO);
            var savedCourseModule = _courseModuleRepository.Save(courseModuleToSave);

            return _mapper.Map<CourseModuleDTO>(savedCourseModule);
        }

        public void DeleteCourseModuleById(int id)
        {
            if (!_courseModuleRepository.ExistsById(id))
            {
                throw new ResourceNotFoundException($"Course module not found with id {id}");
            }

            _courseModuleRepository.DeleteById(id);
        }

        public LearningPathDTO GetAllCourseModules()
        {
            var courseModules = _courseModuleRepository.FindAll();
            return new LearningPathDTO
            {
                Modules = _mapper.Map<List<CourseModuleDTO>>(courseModules)
            };
        }

        public LearningPathDTO GetAllCourseModulesAndTheirTutorials()
        {
            var courseModules = _courseModuleRepository.FindAllAndTheirTutorials();
            return new LearningPathDTO
            {
                Modules = _mapper.Map<List<CourseModuleDTO>>(courseModules)
            };
        }

        private void CheckForDuplicateCourseModule(CourseModuleDTO courseModuleDTO)
        {
            if (_courseModuleRepository.ExistsByTitle(courseModuleDTO.Title))
            {
                throw new DuplicateResourceException($"Course module already exists with title {courseModuleDTO.Title}");
            }
            else if (_courseModuleRepository.ExistsByNumber(courseModuleDTO.Number))
            {
                throw new DuplicateResourceException($"Course module already exists with number {courseModuleDTO.Number}");
            }
        }
    }

}
