'use client'

import { useState } from 'react'
import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Card, CardContent, CardHeader, CardTitle, CardDescription, CardFooter } from "@/components/ui/card"
import { Package } from "lucide-react"
import { signIn } from "next-auth/react"

import { loginAction } from "@/actions/auth"

export default function LoginPage() {
    const [loading, setLoading] = useState(false)
    const [error, setError] = useState<string | null>(null)

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault()
        setLoading(true)
        setError(null)

        const formData = new FormData(e.currentTarget)
        const res = await loginAction(formData)

        if (res) {
            setError(res)
            setLoading(false)
        }
        // Redirect is handled by signIn in Auth.js v5 if callbackUrl is provided or defaults.
        // Actually, signIn helper in server actions usually throws redirect, but here we return error strings.
    }

    return (
        <div className="flex min-h-screen items-center justify-center bg-muted/40 p-4">
            <Card className="w-full max-w-md">
                <CardHeader className="text-center">
                    <div className="flex justify-center mb-4">
                        <Package className="h-12 w-12 text-primary" />
                    </div>
                    <CardTitle className="text-2xl font-bold">Inventory Brother</CardTitle>
                    <CardDescription>Enter your credentials to access the ERP</CardDescription>
                </CardHeader>
                <form onSubmit={handleSubmit}>
                    <CardContent className="space-y-4">
                        {error && (
                            <div className="bg-destructive/10 text-destructive text-sm p-3 rounded-md text-center">
                                {error}
                            </div>
                        )}
                        <div className="space-y-2">
                            <label className="text-sm font-medium">Username</label>
                            <Input type="text" name="username" placeholder="admin" required />
                        </div>
                        <div className="space-y-2">
                            <label className="text-sm font-medium">Password</label>
                            <Input type="password" name="password" placeholder="••••••••" required />
                        </div>
                    </CardContent>
                    <CardFooter>
                        <Button className="w-full" type="submit" disabled={loading}>
                            {loading ? "Signing in..." : "Sign In"}
                        </Button>
                    </CardFooter>
                </form>
            </Card>
        </div>
    )
}
