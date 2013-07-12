var ContentRouting = {
    numberOfEmployee: {
        title: "อัตรากำลัง",
        imageUrl: "Charts/iPad/NumberOfEmployee.ashx",
        draggable: false,
        buttons: {
            detail: {
                title: "อัตรากำลัง - รายละเอียด",
                imageUrl: "Charts/iPad/NumberOfEmployeeDetail.ashx"
            },
            compare: {
                title: "อัตรากำลัง - เปรียบเทียบรายปี",
                imageUrl: "Charts/iPad/NumberOfEmployeeCompare.ashx",
                draggable: false,
                hideYear: true
            }
        }
    },
    estimatedRetirement: {
        title: "ประมาณการอัตรากำลังเกษียณ",
        imageUrl: "Charts/iPad/EstimatedRetirement.ashx",
        buttons: {},
        draggable: false,
        yearOffset: 1
    },
    estimatedFundMember: {
        title: "สมาชิก กบข./กสจ.",
        imageUrl: "Charts/iPad/EstimatedFundMember.ashx",
        draggable: false,
        buttons: {
            compareonly: {
                title: "สมาชิก กบข./กสจ. - เทียบรายปี",
                imageUrl: "Charts/iPad/EstimatedFundmemberCompare.ashx",
                draggable: false
            }
        }
    },
    budgetUsage: {
        title: "การเบิกจ่ายเงินงบประมาณภาพรวม",
        imageUrl: "Charts/iPad/BudgetUsage.ashx",
        draggable: false,
        buttons: {
            compareonly: {
                title: "การเบิกจ่ายเงินงบประมาณภาพรวม - เทียบรายปี",
                imageUrl: "Charts/iPad/BudgetUsageCompare.ashx",
                draggable: false
            }
        }
    },
    employeeRelatedBudgetUsage: {
        title: "การจ่ายเงินงบบุคลากร",
        imageUrl: "Charts/iPad/EmployeeRelatedBudget.ashx",
        draggable: false,
        buttons: {
            compareonly: {
                title: "การจ่ายงบบุคลากร - เปรียบเทียบรายปี",
                imageUrl: "Charts/iPad/EmployeeRelatedBudgetCompare.ashx",
                draggable: true,
                height: 2
            }
        }
    },
    retirementFundUsage: {
        title: "การเบิกจ่ายบำเหน็จบำนาญ",
        imageUrl: "Charts/iPad/RetirementFundUsage.ashx",
        draggable: false,
        buttons: {}
    },
    warrantFundProviding: {
        title: "การอนุมัติเงินกู้ของสถาบันการเงิน (จำนวนเงิน)",
        imageUrl: "Charts/iPad/BankLoanApproval.ashx",
        draggable: false,
        buttons: {
            one: {
                title: "การอนุมัติเงินกู้ของสถาบันการเงิน",
                imageUrl: "Charts/iPad/BankLoanApproval.ashx",
                draggable: false,
                buttonText: "อนุมัติกู้<br>(เงิน)",
                fontSize: 8
            },
            two: {
                title: "การอนุมัติเงินกู้ของสถาบันการเงิน",
                imageUrl: "Charts/iPad/BankLoanApprovalToPeople.ashx",
                draggable: false,
                buttonText: "อนุมัติกู้<br>(คน)",
                fontSize: 8
            },
            three: {
                title: "การออกหนังสือรับรองสิทธิ์",
                imageUrl: "Charts/iPad/WarrantFundProviding.ashx",
                draggable: false,
                buttonText: "หนังสือรับรอง<br>(เงิน)",
                fontSize: 8
            },
            four: {
                title: "การออกหนังสือรับรองสิทธิ์",
                imageUrl: "Charts/iPad/WarrantFundProvidingToPeople.ashx",
                draggable: false,
                buttonText: "หนังสือรับรอง<br>(คน)",
                fontSize: 8
            }
        }
    },
    firstCarStatus: {
        title: "รถคันแรก - จำนวนคน",
        imageUrl: "Charts/iPad/FirstCarStatusByPeople.ashx",
        draggable: false,
        buttons: {
            one: {
                title: "รถคันแรก - จำนวนคน",
                imageUrl: "Charts/iPad/FirstCarStatusByPeople.ashx",
                draggable: false,
                buttonText: "จำนวนคน",
                fontSize: 10
            },
            two: {
                title: "รถคันแรก - จำนวนเงิน",
                imageUrl: "Charts/iPad/FirstCarStatusByAmount.ashx",
                draggable: false,
                buttonText: "จำนวนเงิน",
                fontSize: 10
            }
        }
    }
}