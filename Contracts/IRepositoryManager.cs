﻿namespace Contracts;

public interface IRepositoryManager
{
	ICompanyRepository Company { get; }
	IUserRepository User { get; }
	Task SaveAsync();
}
