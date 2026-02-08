'use client'

import { useState } from "react"
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs"
import { Separator } from "@/components/ui/separator"

interface FinancialReportsProps {
    balanceSheet: any
    profitLoss: any
}

import { useTranslations } from "next-intl"

export function FinancialReports({ balanceSheet, profitLoss }: FinancialReportsProps) {
    const t = useTranslations("Finance")

    return (
        <Tabs defaultValue="pl" className="w-full">
            <TabsList className="grid w-full grid-cols-2">
                <TabsTrigger value="pl">{t("profitLoss")}</TabsTrigger>
                <TabsTrigger value="bs">{t("balanceSheet")}</TabsTrigger>
            </TabsList>

            <TabsContent value="pl">
                <Card>
                    <CardHeader>
                        <CardTitle>{t("profitLoss")}</CardTitle>
                    </CardHeader>
                    <CardContent className="space-y-6">
                        {/* Revenue Section */}
                        <div className="space-y-2">
                            <h3 className="font-bold text-lg border-b pb-1">{t("revenueLabel")}</h3>
                            {profitLoss.revenue.map((r: any) => (
                                <ReportLine key={r.accountId} label={r.name} amount={r.balance} />
                            ))}
                            <div className="flex justify-between font-bold pt-2 border-t mt-2">
                                <span>{t("total")} {t("revenueLabel")}</span>
                                <span>{profitLoss.totalRevenue.toFixed(2)}</span>
                            </div>
                        </div>

                        {/* Expense Section */}
                        <div className="space-y-2">
                            <h3 className="font-bold text-lg border-b pb-1 text-red-700">{t("expenseLabel")}</h3>
                            {profitLoss.expenses.map((e: any) => (
                                <ReportLine key={e.accountId} label={e.name} amount={e.balance} negative />
                            ))}
                            <div className="flex justify-between font-bold pt-2 border-t mt-2">
                                <span>{t("total")} {t("expenseLabel")}</span>
                                <span>{profitLoss.totalExpenses.toFixed(2)}</span>
                            </div>
                        </div>

                        <Separator />

                        {/* Net Profit */}
                        <div className="flex justify-between text-xl font-bold p-4 bg-slate-50 rounded-lg">
                            <span>{t("netProfit")}</span>
                            <span className={profitLoss.netProfit >= 0 ? "text-green-600" : "text-red-600"}>
                                {profitLoss.netProfit.toFixed(2)}
                            </span>
                        </div>
                    </CardContent>
                </Card>
            </TabsContent>

            <TabsContent value="bs">
                <Card>
                    <CardHeader>
                        <CardTitle>{t("balanceSheet")}</CardTitle>
                    </CardHeader>
                    <CardContent className="grid grid-cols-1 md:grid-cols-2 gap-10">
                        {/* Assets Side */}
                        <div className="space-y-6">
                            <div className="space-y-2">
                                <h3 className="font-bold text-lg border-b pb-1 text-primary">{t("assets")}</h3>
                                {balanceSheet.assets.map((a: any) => (
                                    <ReportLine key={a.accountId} label={a.name} amount={a.balance} />
                                ))}
                                <div className="flex justify-between font-bold pt-2 border-t mt-2 bg-slate-50 px-2 py-1">
                                    <span>{t("total")} {t("assets")}</span>
                                    <span>{balanceSheet.totalAssets.toFixed(2)}</span>
                                </div>
                            </div>
                        </div>

                        {/* Liabilities & Equity Side */}
                        <div className="space-y-6">
                            <div className="space-y-2">
                                <h3 className="font-bold text-lg border-b pb-1 text-amber-700">{t("liabilities")}</h3>
                                {balanceSheet.liabilities.map((l: any) => (
                                    <ReportLine key={l.accountId} label={l.name} amount={l.balance} />
                                ))}
                                <div className="flex justify-between font-bold pt-2 border-t mt-2 bg-slate-50 px-2 py-1">
                                    <span>{t("total")} {t("liabilities")}</span>
                                    <span>{balanceSheet.totalLiabilities.toFixed(2)}</span>
                                </div>
                            </div>

                            <div className="space-y-2 pt-4">
                                <h3 className="font-bold text-lg border-b pb-1 text-slate-700">{t("equity")}</h3>
                                {balanceSheet.equity.map((e: any) => (
                                    <ReportLine key={e.id} label={e.name} amount={e.balance} />
                                ))}
                                <div className="flex justify-between font-bold pt-2 border-t mt-2 bg-slate-50 px-2 py-1">
                                    <span>{t("total")} {t("equity")}</span>
                                    <span>{balanceSheet.totalEquity.toFixed(2)}</span>
                                </div>
                            </div>

                            <Separator />

                            <div className="flex justify-between font-bold text-lg p-2 bg-slate-100 rounded">
                                <span>{t("total")} {t("liabilities")} & {t("equity")}</span>
                                <span>{(balanceSheet.totalLiabilities + balanceSheet.totalEquity).toFixed(2)}</span>
                            </div>

                            {/* Balance Check */}
                            {Math.abs(balanceSheet.totalAssets - (balanceSheet.totalLiabilities + balanceSheet.totalEquity)) > 0.01 && (
                                <p className="text-xs text-red-500 italic text-right">
                                    {t("balanceWarning")} {(balanceSheet.totalAssets - (balanceSheet.totalLiabilities + balanceSheet.totalEquity)).toFixed(2)}
                                </p>
                            )}
                        </div>
                    </CardContent>
                </Card>
            </TabsContent>
        </Tabs>
    )
}

function ReportLine({ label, amount, negative = false }: { label: string, amount: number, negative?: boolean }) {
    if (Math.abs(amount) < 0.01) return null
    return (
        <div className="flex justify-between text-sm hover:bg-slate-50 px-2 py-1 rounded transition-colors">
            <span>{label}</span>
            <span className={negative ? "text-red-500" : ""}>
                {amount < 0 ? `(${Math.abs(amount).toFixed(2)})` : `${amount.toFixed(2)}`}
            </span>
        </div>
    )
}
