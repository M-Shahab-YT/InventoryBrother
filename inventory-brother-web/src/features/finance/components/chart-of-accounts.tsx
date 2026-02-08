'use client'

import React, { useState } from "react"
import { FinanceAccount } from "@/db/schema"
import { Button } from "@/components/ui/button"
import { Plus, Edit2, ChevronRight, ChevronDown } from "lucide-react"
import { useTranslations } from "next-intl"
import { AccountDialog } from "./account-dialog"
import {
    Table,
    TableBody,
    TableCell,
    TableHead,
    TableHeader,
    TableRow,
} from "@/components/ui/table"

interface ChartOfAccountsProps {
    accounts: FinanceAccount[]
}

const ACCOUNT_TYPES = ["Asset", "Liability", "Equity", "Revenue", "Expense"]

export function ChartOfAccounts({ accounts }: ChartOfAccountsProps) {
    const t = useTranslations("Finance")
    const [selectedAccount, setSelectedAccount] = useState<FinanceAccount | null>(null)
    const [dialogOpen, setDialogOpen] = useState(false)

    const handleAdd = () => {
        setSelectedAccount(null)
        setDialogOpen(true)
    }

    const handleEdit = (account: FinanceAccount) => {
        setSelectedAccount(account)
        setDialogOpen(true)
    }

    // Group accounts by type for the top-level categories
    const groupedAccounts = ACCOUNT_TYPES.map(type => ({
        type,
        items: accounts.filter(a => a.type === type && !a.parentId)
    }))

    return (
        <div className="space-y-4">
            <div className="flex justify-between items-center">
                <h2 className="text-xl font-semibold">{t("accountList")}</h2>
                <Button onClick={handleAdd}>
                    <Plus className="h-4 w-4 mr-2" /> {t("addAccount")}
                </Button>
            </div>

            <div className="border rounded-md bg-white">
                <Table>
                    <TableHeader>
                        <TableRow>
                            <TableHead className="w-[100px]">{t("accountCode")}</TableHead>
                            <TableHead>{t("accountName")}</TableHead>
                            <TableHead>{t("type")}</TableHead>
                            <TableHead className="text-right">{t("actions")}</TableHead>
                        </TableRow>
                    </TableHeader>
                    <TableBody>
                        {groupedAccounts.map(group => (
                            <React.Fragment key={group.type}>
                                <TableRow key={group.type} className="bg-slate-50 font-bold">
                                    <TableCell colSpan={4} className="uppercase text-xs tracking-wider text-slate-500">
                                        {t(group.type.toLowerCase() as any)}s
                                    </TableCell>
                                </TableRow>
                                {group.items.length === 0 && (
                                    <TableRow>
                                        <TableCell colSpan={4} className="text-center py-4 text-muted-foreground text-sm italic">
                                            {t("noAccountsDefined", { type: t(group.type.toLowerCase() as any) })}
                                        </TableCell>
                                    </TableRow>
                                )}
                                {group.items.map(account => (
                                    <AccountRow
                                        key={account.id}
                                        account={account}
                                        allAccounts={accounts}
                                        onEdit={handleEdit}
                                        level={0}
                                    />
                                ))}
                            </React.Fragment>
                        ))}
                    </TableBody>
                </Table>
            </div>

            <AccountDialog
                open={dialogOpen}
                onOpenChange={setDialogOpen}
                account={selectedAccount}
                accounts={accounts}
            />
        </div>
    )
}

function AccountRow({ account, allAccounts, onEdit, level }: {
    account: FinanceAccount,
    allAccounts: FinanceAccount[],
    onEdit: (a: FinanceAccount) => void,
    level: number
}) {
    const t = useTranslations("Finance")
    const children = allAccounts.filter(a => a.parentId === account.id)
    const [expanded, setExpanded] = useState(true)

    return (
        <>
            <TableRow className="group">
                <TableCell className="font-mono text-sm">{account.code}</TableCell>
                <TableCell style={{ paddingLeft: `${level * 2 + 1}rem` }}>
                    <div className="flex items-center gap-2">
                        {children.length > 0 ? (
                            <button onClick={() => setExpanded(!expanded)}>
                                {expanded ? <ChevronDown className="h-3 w-3" /> : <ChevronRight className="h-3 w-3" />}
                            </button>
                        ) : <div className="w-3" />}
                        <span className={children.length > 0 ? "font-medium" : ""}>
                            {account.name}
                        </span>
                    </div>
                </TableCell>
                <TableCell className="text-xs text-muted-foreground">{t(account.type.toLowerCase() as any)}</TableCell>
                <TableCell className="text-right">
                    <Button variant="ghost" size="icon" onClick={() => onEdit(account)}>
                        <Edit2 className="h-3 w-3" />
                    </Button>
                </TableCell>
            </TableRow>
            {expanded && children.map(child => (
                <AccountRow
                    key={child.id}
                    account={child}
                    allAccounts={allAccounts}
                    onEdit={onEdit}
                    level={level + 1}
                />
            ))}
        </>
    )
}
