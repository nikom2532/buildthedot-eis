var dataFormMapping = {
    numberOfEmployee: {
        apiUrl: 'api/numberofemployee',
        fields: {
            "Year": { editable: false, nullable: true },
            "EmployeeType.TypeName": { editable: false, nullable: true },
            "GovernmentOfficer": { editable: true, nullable: true, type: "number" },
            "PermanentContractor": { editable: true, nullable: true, type: "number" },
            "GeneralOfficer": { editable: true, nullable: true, type: "number" }
        },
        columns: [
            { title: "ปี", field: "Year" },
            { title: "ประเภท", field: "EmployeeType.TypeName" },
            { title: "ข้าราชการ", field: "GovernmentOfficer" },
            { title: "ลูกจ้างประจำ", field: "PermanentContractor" },
            { title: "พนักงานราชการ", field: "GeneralOfficer" }
        ]
    },
    estimatedRetirement: {
        apiUrl: 'api/estimatedRetirement',
        fields: {
            "Year": { editable: false, nullable: true },
            "RetirementType.TypeName": { editable: false, nullable: true },
            "EstimatedValue": { editable: true, nullable: true, type: "number" },
        },
        columns: [
            { title: "ปี", field: "Year" },
            { title: "ประเภท", field: "RetirementType.TypeName" },
            { title: "จำนวน", field: "EstimatedValue" }
        ]
    },
    estimatedFundMember: {
        apiUrl: 'api/estimatedFundMember',
        fields: {
            "Year": { editable: false, nullable: true },
            "FundMemberType.TypeName": { editable: false, nullable: true },
            "EstimatedValue": { editable: true, nullable: true, type: "number" },
        },
        columns: [
            { title: "ปี", field: "Year" },
            { title: "ประเภท", field: "FundMemberType.TypeName" },
            { title: "จำนวน", field: "EstimatedValue" }
        ]
    },
    budgetUsage: {
        apiUrl: 'api/budgetUsage',
        fields: {
            "Year": { editable: false, nullable: true },
            "BudgetType.TypeName": { editable: false, nullable: true },
            "BudgetAmount": { editable: true, nullable: true, type: "number" },
            "Used": { editable: true, nullable: true, type: "number" }
        },
        columns: [
            { title: "ปี", field: "Year" },
            { title: "ประเภท", field: "BudgetType.TypeName" },
            { title: "งบประมาณ", field: "BudgetAmount" },
            { title: "เบิกจ่าย", field: "Used" }
        ]
    },
    employeeRelatedBudgetUsage: {
        apiUrl: 'api/employeeRelatedBudgetUsage',
        fields: {
            "Year": { editable: false, nullable: true },
            "EmployeeRelatedBudgetType.TypeName": { editable: false, nullable: true },
            "Amount": { editable: true, nullable: true, type: "number" }
        },
        columns: [
            { title: "ปี", field: "Year" },
            { title: "ประเภท", field: "EmployeeRelatedBudgetType.TypeName" },
            { title: "เบิกจ่าย", field: "Amount" }
        ]
    },
    retirementFundUsage: {
        apiUrl: 'api/retirementFundUsage',
        fields: {
            "Year": { editable: false, nullable: true },
            "RetirementFundType.TypeName": { editable: false, nullable: true },
            "NumberOfPeople": { editable: true, nullable: true, type: "number" },
            "NumberOfUsage": { editable: true, nullable: true, type: "number" }
        },
        columns: [
            { title: "ปี", field: "Year" },
            { title: "ประเภท", field: "RetirementFundType.TypeName" },
            { title: "เจ้าของสิทธิ", field: "NumberOfPeople" },
            { title: "จำนวน(ล้านบาท)", field: "NumberOfUsage" }
        ]
    },
    warrantFund: {
        apiUrl: 'api/warrantFundProviding',
        fields: {
            "Year": { editable: false, nullable: true },
            "WarrantFundProvider.ProviderName": { editable: false, nullable: true },
            "NumberOfPeople": { editable: true, nullable: true, type: "number" },
            "Amount": { editable: true, nullable: true, type: "number" }
        },
        columns: [
            { title: "ปี", field: "Year" },
            { title: "หน่วยงาน", field: "WarrantFundProvider.ProviderName" },
            { title: "ราย", field: "NumberOfPeople" },
            { title: "จำนวน(ล้านบาท)", field: "Amount" }
        ]
    },
    firstCarStatus: {
        apiUrl: 'api/firstCarStatus',
        fields: {
            "Year": { editable: false, nullable: true },
            "FirstCarStatusType.StatusName": { editable: false, nullable: true },
            "NumberOfPeople": { editable: true, nullable: true, type: "number" },
            "Amount": { editable: true, nullable: true, type: "number" }
        },
        columns: [
            { title: "ปี", field: "Year" },
            { title: "สถานะ", field: "FirstCarStatusType.StatusName" },
            { title: "ราย", field: "NumberOfPeople" },
            { title: "จำนวน(ล้านบาท)", field: "Amount" }
        ]
    },
    bankLoanApproval: {
        apiUrl: 'api/bankLoanApproval',
        fields: {
            "Year": { editable: false, nullable: true },
            "BankType.BankName": { editable: false, nullable: true },
            "NumberOfPeople": { editable: true, nullable: true, type: "number" },
            "Amount": { editable: true, nullable: true, type: "number" }
        },
        columns: [
            { title: "ปี", field: "Year" },
            { title: "สถาบันการเงิน", field: "BankType.BankName" },
            { title: "ราย", field: "NumberOfPeople" },
            { title: "จำนวน(ล้านบาท)", field: "Amount" }
        ]
    }
}