export interface Project{
    projectId: number,
    projectName: string,
    isActive: boolean,
    departmentId: number,
    department: string,
    employeesUnderProject: []
}