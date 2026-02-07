import Link from 'next/link';
// Basic wrapper to avoid import errors in layout if we switch strictly to next-intl navigation later.
// For now, standard next/link works as we are not using localized paths (e.g. /en/...) yet 
// effectively/enforcing it in middleware yet. 
// If using [locale] param, this should be real next-intl navigation.
export { Link };
