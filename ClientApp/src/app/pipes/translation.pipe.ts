import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'translation' })
export class TranslationPipe implements PipeTransform {
  transform(value: ProductTranslation[], display?: string): string {
    const currentLocale = this.getUsersLocale('en-GB');
    const empty: ProductTranslation = { culture: currentLocale, name: "[MISSING_TRANSLATION]", description: "" };
    let displayValue = value.find(x => x.culture.startsWith(currentLocale));

    if (!displayValue) {
        displayValue = value.length == 0 ? empty : value[0];
    }

    if (display) {
        return displayValue[display];
    }

    return displayValue.name;
  }

  getUsersLocale(defaultValue: string): string {
    if (typeof window === 'undefined' || typeof window.navigator === 'undefined') {
      return defaultValue;
    }
    const wn = window.navigator as any;
    let lang = wn.languages ? wn.languages[0] : defaultValue;
    lang = lang || wn.language || wn.browserLanguage || wn.userLanguage;
    return lang;
  }
}