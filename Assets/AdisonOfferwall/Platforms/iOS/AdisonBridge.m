#import <AdisonOfferwallSDK/AdisonOfferwallSDK-Swift.h>

/// Returns an NSString copying the characters from |bytes|, a C array of UTF8-encoded bytes.
/// Returns nil if |bytes| is NULL.
static NSString *GADUStringFromUTF8String(const char *bytes) { return bytes ? @(bytes) : nil; }

/// Returns a C string from a C array of UTF8-encoded bytes.
static const char *cStringCopy(const char *string) {
  if (!string) {
    return NULL;
  }
  char *res = (char *)malloc(strlen(string) + 1);
  strcpy(res, string);
  return res;
}

/// Returns a C string from a C array of UTF8-encoded bytes.
static const char **cStringArrayCopy(NSArray *array) {
  if (array == nil) {
    return nil;
  }

  const char **stringArray;

  stringArray = calloc(array.count, sizeof(char *));
  for (int i = 0; i < array.count; i++) {
    stringArray[i] = cStringCopy([array[i] UTF8String]);
  }
  return stringArray;
}

void __initialize(const char *appKey) {
    [[Adison shared] initializeWith:GADUStringFromUTF8String(appKey)];
}

void __setDebugEnabled(bool enable) {
    // do nothing yet
}

void __setUid(const char *uid) {
    [[Adison shared] setUid:GADUStringFromUTF8String(uid)];
}

void __setIsTester(bool enable) {
    [[Adison shared] isTester:enable];
}

void __setServer(int env) {
    if (env == 0) {
        [[Adison shared] setServer:StageDevelopment];
    } else if (env == 1) {
        [[Adison shared] setServer:StageStaging];
    } else if (env == 2) {
        [[Adison shared] setServer:StageProduction];
    }
}

void __setBirthYear(int birthYear) {
    [[Adison shared] setBirthYear:birthYear];
}

void __setGender(int gender) {
 if (gender == 0) {
     [[Adison shared] setGender:GenderUnknown];
 } else if (gender == 1) {
     [[Adison shared] setGender:GenderMale];
 } else if (gender == 2) {
     [[Adison shared] setGender:GenderFemale];
 }
}

void __showOfferwall() {
    UIViewController* viewController = UnityGetGLViewController();
    [[Adison shared] presentOfferwall:viewController adId:nil animated:NO completion:nil];
}
