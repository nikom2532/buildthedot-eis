var ContentRouting = {
    numberOfEmployee: {
        title: "อัตรากำลัง",
        imageUrl: "Charts/NumberOfEmployee.ashx",
        draggable: false,
        buttons: {
            detail: {
                title: "อัตรากำลัง - รายละเอียด",
                imageUrl: "Charts/NumberOfEmployeeDetail.ashx"
            },
            compare: {
                title: "อัตรากำลัง - เปรียบเทียบรายปี",
                imageUrl: "Charts/NumberOfEmployeeCompare.ashx",
                draggable: false,
                hideYear: true
            }
        }
    },
    estimatedRetirement: {
        title: "ประมาณการอัตรากำลังเกษียณ",
        imageUrl: "Charts/EstimatedRetirement.ashx",
        buttons: {},
        draggable: false,
        yearOffset: 1
    },
    estimatedFundMember: {
        title: "สมาชิก กบข./กสจ.",
        imageUrl: "Charts/EstimatedFundMember.ashx",
        draggable: false,
        buttons: {
            compareonly: {
                title: "สมาชิก กบข./กสจ. - เทียบรายปี",
                imageUrl: "Charts/EstimatedFundmemberCompare.ashx",
                draggable: false
            }
        }
    },
    budgetUsage: {
        title: "การเบิกจ่ายเงินงบประมาณภาพรวม",
        imageUrl: "Charts/BudgetUsage.ashx",
        draggable: false,
        buttons: {
            compareonly: {
                title: "การเบิกจ่ายเงินงบประมาณภาพรวม - เทียบรายปี",
                imageUrl: "Charts/BudgetUsageCompare.ashx",
                draggable: false
            }
        }
    },
    employeeRelatedBudgetUsage: {
        title: "การจ่ายเงินงบบุคลากร",
        imageUrl: "Charts/EmployeeRelatedBudget.ashx",
        draggable: false,
        buttons: {
            compareonly: {
                title: "การจ่ายงบบุคลากร - เปรียบเทียบรายปี",
                imageUrl: "Charts/EmployeeRelatedBudgetCompare.ashx",
                draggable: true,
                height: 2
            }
        }
    },
    retirementFundUsage: {
        title: "การเบิกจ่ายบำเหน็จบำนาญ",
        imageUrl: "Charts/RetirementFundUsage.ashx",
        draggable: false,
        buttons: {}
    },
    warrantFundProviding: {
        title: "การอนุมัติเงินกู้ของสถาบันการเงิน (จำนวนเงิน)",
        imageUrl: "Charts/BankLoanApproval.ashx",
        draggable: false,
        buttons: {
            one: {
                title: "การอนุมัติเงินกู้ของสถาบันการเงิน",
                imageUrl: "Charts/BankLoanApproval.ashx",
                draggable: false,
                buttonText: "อนุมัติกู้<br>(เงิน)",
                fontSize: 8
            },
            two: {
                title: "การอนุมัติเงินกู้ของสถาบันการเงิน",
                imageUrl: "Charts/BankLoanApprovalToPeople.ashx",
                draggable: false,
                buttonText: "อนุมัติกู้<br>(คน)",
                fontSize: 8
            },
            three: {
                title: "การออกหนังสือรับรองสิทธิ์",
                imageUrl: "Charts/WarrantFundProviding.ashx",
                draggable: false,
                buttonText: "หนังสือรับรอง<br>(เงิน)",
                fontSize: 8
            },
            four: {
                title: "การออกหนังสือรับรองสิทธิ์",
                imageUrl: "Charts/WarrantFundProvidingToPeople.ashx",
                draggable: false,
                buttonText: "หนังสือรับรอง<br>(คน)",
                fontSize: 8
            }
        }
    },
    firstCarStatus: {
        title: "รถคันแรก - จำนวนคน",
        imageUrl: "Charts/FirstCarStatusByPeople.ashx",
        draggable: false,
        buttons: {
            one: {
                title: "รถคันแรก - จำนวนคน",
                imageUrl: "Charts/FirstCarStatusByPeople.ashx",
                draggable: false,
                buttonText: "จำนวนคน",
                fontSize: 10
            },
            two: {
                title: "รถคันแรก - จำนวนเงิน",
                imageUrl: "Charts/FirstCarStatusByAmount.ashx",
                draggable: false,
                buttonText: "จำนวนเงิน",
                fontSize: 10
            }
        }
    }
}