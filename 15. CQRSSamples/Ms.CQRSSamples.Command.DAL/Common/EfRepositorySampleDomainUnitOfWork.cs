﻿namespace Ms.CQRSSamples.Command.DAL.Common;

public class EfRepositorySampleDomainUnitOfWork(RepSampleCommandDbContext commandDbContext) : BaseEfUnitOfWork<RepSampleCommandDbContext>(commandDbContext), IRepositorySampleDomainUnitOfWork;