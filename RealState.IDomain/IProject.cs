using RealState.Model.Project;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealState.IDomain
{
    public interface IProject
    {
        List<Project> GetAll();
        List<Project> GetAll(City city);
    }
}
