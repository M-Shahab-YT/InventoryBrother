"use client"

import * as React from "react"
import { usePathname, useRouter } from "@/i18n/navigation"
import { useLocale } from "next-intl"

import {
    Select,
    SelectContent,
    SelectItem,
    SelectTrigger,
    SelectValue,
} from "@/components/ui/select"

export function LanguageSwitcher() {
    const router = useRouter()
    const pathname = usePathname()
    const locale = useLocale()

    const handleValueChange = (value: string) => {
        router.replace(pathname, { locale: value })
    }

    return (
        <Select value={locale} onValueChange={handleValueChange}>
            <SelectTrigger className="w-[100px]">
                <SelectValue placeholder="Language" />
            </SelectTrigger>
            <SelectContent>
                <SelectItem value="en">English</SelectItem>
                <SelectItem value="ps">پښتو</SelectItem>
            </SelectContent>
        </Select>
    )
}
