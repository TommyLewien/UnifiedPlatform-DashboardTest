import { Dispatch, SetStateAction } from "react";

import {
  ISerializationContext,
  serializeObject,
  deSerializeObject,
  ILoggingContext,
  deSerializeObjectFromLocalStore,
} from "discom-project";

export interface IPreferenceSettings {
  locale: string;
  isLightTheme: boolean;
}

const storageClass = "PreferenceSettings";
const instance = "Standard";
export const loadPreferenceData = async (
  currentPrefs: IPreferenceSettings,
  setLocale: Dispatch<SetStateAction<string>>,
  setThemeLight: Dispatch<SetStateAction<boolean>>,
  sc: ISerializationContext,
  lc: ILoggingContext
) => {
  const selPref: IPreferenceSettings | undefined =
    await deSerializeObject<IPreferenceSettings>(
      sc,
      storageClass,
      instance,
      lc,
      true
    );

  if (selPref !== undefined) {
    // the setLocale & setThemeLight will cause a re-render of the whole app.
    // do int only when necessary, especially at app start which already read out
    // the last settings from the cookies
    if (currentPrefs.locale !== selPref.locale) setLocale(selPref.locale);
    if (currentPrefs.isLightTheme !== selPref.isLightTheme)
      setThemeLight(selPref.isLightTheme);
  } else {
    // nothing know yet. Store the current settings so next time they will come up again
    storePreferenceData(currentPrefs, sc, lc);
  }
};

export const storePreferenceData = async (
  prefs: IPreferenceSettings,
  sc: ISerializationContext,
  lc: ILoggingContext
) => {
  await serializeObject<IPreferenceSettings>(
    sc,
    storageClass,
    instance,
    prefs,
    lc,
    true
  );
};

export const defaultLocale = (application: string, user: string): string => {
  const selPref: IPreferenceSettings | undefined =
    deSerializeObjectFromLocalStore<IPreferenceSettings>(
      application,
      user,
      storageClass,
      instance
    );
  if (selPref !== undefined) return selPref.locale;
  const defaultLang: string = navigator.language;
  return defaultLang;
};

export const defaultIsLightTheme = (
  application: string,
  user: string
): boolean => {
  const selPref: IPreferenceSettings | undefined =
    deSerializeObjectFromLocalStore<IPreferenceSettings>(
      application,
      user,
      storageClass,
      instance
    );
  if (selPref !== undefined) return selPref.isLightTheme;
  return true;
};
